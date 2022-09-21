using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Audio;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

namespace SideScrollControl
{
    /// <summary>
    /// side scroller script. player needs: Playerinput(setup properly), rigidbody, collider (adjust to prper collider in code),
    /// sprite renderer, animator (double check animation strings), and this script.
    /// Testing is set at 10 gravity scale for this player (not world) and a jump power of 13. speed is same
    /// no other major dependancies
    /// </summary>
    public class SideScrollControls : MonoBehaviour
    {
        //serialized
        [Header("Movement")]
        [SerializeField] float playerCurrentSpeed = 10f;
        [Header("Jump")]
        [SerializeField] float playerJumpPower = 10f;
        [SerializeField] float fallMultiplier = 2.5f;
        [SerializeField] float lowJumpPower = 2f;
        [SerializeField] float hangTime = .1f;
        [SerializeField] float jumpGraceLength = .1f;
        [SerializeField] int jumpBufferFramesMax = 4;
        [SerializeField] int jumpCountMax = 1;

        //private
        Rigidbody2D myRigidbody;
        Animator myAnimator;
        PlayerInput myPlayerInput;
        BoxCollider2D myBoxCollider;
        BoxCollider2D feetBoxCollider;
        //SpriteRenderer mySpriteRenderer;
        

        Vector2 controllerMovement;

        float hangTimeCounter;
        int jumpBufferTimer;
        bool air;
        bool cayoteActive;
        bool hasJumped;
        bool onLand;
        bool jumpBufferCanJump;
        int jumpCount;

        float xThrow;

        bool canMove;
        [HideInInspector] public bool isMoving;
        bool isJumping;

        float counter = 2;
        bool charging = false;

        [Header("ChargeJump")]
        [SerializeField] float bernyChargeJump;

        [Header("UI")]
        [SerializeField] UI.MenuManager myMenuManager;

        [SerializeField] Projectile.Gun bernieGun;


        // Start is called before the first frame update
        void Awake()
        {
            //initializers
            myPlayerInput = GetComponent<PlayerInput>();
            myRigidbody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
            myBoxCollider = GetComponent<BoxCollider2D>();
            feetBoxCollider = GameObject.Find("Feet").GetComponent<BoxCollider2D>();
            //mySpriteRenderer = GetComponent<SpriteRenderer>();

            //controller actions
            myPlayerInput.actions["jump"].started += OnJump;
            myPlayerInput.actions["jump"].canceled += OnJump;
            myPlayerInput.actions["MoveDetect"].started += OnMoveDetect;
            myPlayerInput.actions["MoveDetect"].canceled += OnMoveDetect;

            //new controller actions
            myPlayerInput.actions["DiceThrow"].started += OnDiceThrow;
            myPlayerInput.actions["Charge Jump"].started += OnChargeJump;
            myPlayerInput.actions["Charge Jump"].canceled += OnChargeJump;
            myPlayerInput.actions["Pause"].started += OnPause;

            canMove = true;
            jumpCount = jumpCountMax;
        }

        private void Start()
        {
            jumpBufferTimer = jumpBufferFramesMax + 1; //prevents jump upon room load
        }

        private void Update()
        {
            JumpFrameCalculation();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //movement
            Movement();
            FallGravity();
            HangTimeCalculation();
            JumpForce();

            //animation
            FlipSprite();
            AnimateJump();

            //new
            StunEnd();

            
        }

        //movement
        public void OnMoveDetect(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                isMoving = true;
                FindObjectOfType<AudioManager>().Play("Bernie Feet");
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                isMoving = false;
                FindObjectOfType<AudioManager>().Stop("Bernie Feet");
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            controllerMovement = context.ReadValue<Vector2>();
        }

        private void Movement()
        {
            myAnimator.SetBool("Moving", isMoving);
            xThrow = controllerMovement.x;

            if(canMove)
            {
                Vector2 playerVelocity = new Vector2(xThrow * playerCurrentSpeed, myRigidbody.velocity.y);
                myRigidbody.velocity = playerVelocity;

                if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) //checkes for ground
                {
                    myAnimator.SetBool("Land", true); //set landing animation
                    onLand = true; //sets setting to land as half a check to set hangtime

                    air = false; //sets hang time to false to stop hangtime
                    hasJumped = false;
                    jumpCount = jumpCountMax; //resets the jump counter (here for multiple jumps)

                }
                else
                {
                    myAnimator.SetBool("Land", false); //when not touching the land, set animation and on land to false.
                    onLand = false;
                }

                if(!onLand && !hasJumped) //if not on land and the jump button has been pressed, then set the hang time
                {
                    air = true; //air is set on and off for hangtime to start counting down
                }
            }
        }

        //jumping
        private void JumpFrameCalculation() //calculates frames for frame buffering
        {
            if (jumpCount > 0 && hangTimeCounter > 0)
            {
                cayoteActive = true;
            }
            else
            {
                cayoteActive = false;
            }

            if ((myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || cayoteActive) && (jumpBufferTimer < jumpBufferFramesMax))
            {
                jumpBufferCanJump = true;
                jumpBufferTimer = jumpBufferFramesMax;
            }
            else
                jumpBufferCanJump = false;

            jumpBufferTimer++;
        }

        private void HangTimeCalculation() //caclulates time for cayote time
        {
            if (charging && counter > 0)
            {
                counter -= 1 * Time.deltaTime;
            }

            if (air == true)
            {
                hangTimeCounter -= Time.deltaTime;
            }
            else
            {
                hangTimeCounter = hangTime;
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            //detects the input properly
            if(context.phase == InputActionPhase.Started) //when button is pressed
            {
                isJumping = true; //set to true so that bernie doesn't jump when false
                jumpBufferTimer = 0; //resets jump frames
                if(!hasJumped) //sets the has jump bool to true to false 
                {
                    hasJumped = true;
                }
            }
            if(context.phase == InputActionPhase.Canceled) //when button is not pressed
            {
                isJumping = false;
                hangTimeCounter = 0;
                jumpCount--; //this here prevents it from being canceled upon jump
            }
        }

        private void JumpForce()
        {
            if(jumpBufferCanJump)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y * playerJumpPower);

                FindObjectOfType<AudioManager>().Play("Jump");
            }
        }

        private void FallGravity()
        {
            if(myRigidbody.velocity.y < 0) //regular gravity
            {
                myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if(myRigidbody.velocity.y > 0 && !isJumping) //short hop
            {
                myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpPower - 1) * Time.deltaTime;
            }
        }    

        //animation
        private void FlipSprite()
        {
            bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

            if(playerHasHorizontalSpeed)
            {
                transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
            }
        }

        private void AnimateJump() //figures out jump
        {
            if (Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon)
            {
                myAnimator.SetBool("Jump", true);
            }

            if(myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                myAnimator.SetBool("Jump", false);
            }
        }

        //NEW
        //Attack Stun
        public void SetMove()
        {
            canMove = false;
            if(myBoxCollider.enabled == true)
            {
                //StartCoroutine(ColliderShutdown());
            }
        }

        private void StunEnd()
        {
            if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !canMove)
            {
                StartCoroutine(DelayTime());
            }
        }

        IEnumerator ColliderShutdown()
        {
            myBoxCollider.enabled = false;
            yield return new WaitForSeconds(.5f);
            myBoxCollider.enabled = true;
        }

        IEnumerator DelayTime()
        {
            
            yield return new WaitForSeconds(.5f);
            canMove = true;
            myAnimator.SetBool("Damage", false);
            myAnimator.SetBool("Recover", true);
            yield return new WaitForSeconds(.1f);
            myAnimator.SetBool("Recover", false);
            myAnimator.Play("Me IDLE");
        }

        //Moves
        public void OnDiceThrow(InputAction.CallbackContext context)
        {
            GetComponent<DiceMechanics.DiceHolder>().ThrowHeldDice();

            myAnimator.SetTrigger("Throw Dice");
        }

        public void OnChargeJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                myAnimator.SetBool("Charge Jump", true);
                charging = true;
                canMove = false;

                StartCoroutine(ChargeSound());
            }
            if (context.phase == InputActionPhase.Canceled)
            {
                StopAllCoroutines();
                canMove = true;
                if(counter <= 0)
                {
                    myAnimator.SetBool("Charge Jump", false);
                    myRigidbody.velocity += new Vector2(0f, bernyChargeJump);
                    FindObjectOfType<AudioManager>().Play("Charge Jump");
                    counter = 2;
                    charging = false;
                }
                else if(counter > 0)
                {
                    myAnimator.SetBool("Charge Jump", false);
                    counter = 2;
                    charging = false;
                }
            }
        }

        IEnumerator ChargeSound()
        {
            yield return new WaitForSeconds(1.5f);
            FindObjectOfType<AudioManager>().Play("Charge");
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            myMenuManager.PauseGame();
        }

        public void LaunchPlayer()
        {
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.velocity += new Vector2(0f, playerJumpPower);
        }

        public void BreakBernie()
        {
            myAnimator.SetTrigger("Defeat");

            FindObjectOfType<AudioManager>().Play("Big Explosion");

            StartCoroutine(ResetLevel());
        }

        IEnumerator ResetLevel()
        {
            yield return new WaitForSeconds(3f);
            Application.Quit();
        }

        public void PowerMove()
        {
            StartCoroutine(Chaos());
        }

        IEnumerator Chaos()
        {
            playerCurrentSpeed *= 5;
            playerJumpPower *= 5;
            lowJumpPower *= 5;
            bernyChargeJump *= 5;
            yield return new WaitForSeconds(5f);
            playerCurrentSpeed /= 5;
            playerJumpPower /= 5;
            lowJumpPower /= 5;
            bernyChargeJump /= 5;
        }

        public void Arm()
        {
            bernieGun.StartShooting();
        }

        public void DisplayDice(Sprite sprite)
        {
            //myDicePresenter.DisplayDice(sprite);
        }
    }
}

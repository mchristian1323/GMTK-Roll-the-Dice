using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Audio;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using UnityEditor;

namespace SideScrollControl
{
    public class PlayerSideScrollControls : MonoBehaviour
    {
        //serialized
        [Header ("Moving")]
        [SerializeField] float playerBaseSpeed;

        [Header("Jumping")]
        [SerializeField] float playerJumpForce;
        [SerializeField] int jumpBufferFramesTotal = 4;
        [SerializeField] int cayoteFramesTotal = 4;

        //public
        [HideInInspector] public bool isMoving;

        //private
        Vector2 controllerMovement;
        float xThrow;
        bool canMove;

        bool jumpPressed;
        bool hasJumped;
        int jumpBufferFrames;
        int cayoteFrames;

        bool onLand;

        //game specific
        [Header("UI")]
        [SerializeField] UI.MenuManager myMenuManager;
        [Header("Character Attatchments")]
        [SerializeField] Projectile.Gun bernieGun;

        //initializers
        Rigidbody2D myRigidbody;
        Animator myAnimator;
        PlayerInput myPlayerInput;
        BoxCollider2D myBoxCollider;

        // Start is called before the first frame update
        void Awake()
        {
            myPlayerInput = GetComponent<PlayerInput>();
            myRigidbody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
            myBoxCollider = GetComponent<BoxCollider2D>();

            //controller actions
            myPlayerInput.actions["jump"].started += OnJump;
            myPlayerInput.actions["jump"].canceled += OnJump;
            myPlayerInput.actions["MoveDetect"].started += OnMoveDetect;
            myPlayerInput.actions["MoveDetect"].canceled += OnMoveDetect;

            //new controller actions
            myPlayerInput.actions["DiceThrow"].started += OnDiceThrow;
            myPlayerInput.actions["Pause"].started += OnPause;
        }

        void Start()
        {
            canMove = true;
            hasJumped = false;
            jumpBufferFrames = jumpBufferFramesTotal + 1;
            cayoteFramesTotal = cayoteFramesTotal + 1;
        }

        // Update is called once per frame
        void Update()
        {
            if(canMove)
            {
                AdvancedJumpCalculations();
            }
        }

        private void FixedUpdate()
        {
            if(canMove)
            {
                Movement();
            }

            TouchDetecter();

            //animations
            FlipSprite();
            AnimateJump();
            GroundedAnim();
        }

        //controller functions
        public void OnMoveDetect(InputAction.CallbackContext context) //public for player input event
        {
            if(canMove)
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
        }

        public void OnMove(InputAction.CallbackContext context) //public for player input event
        {
            controllerMovement = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context) //public for player input event
        {
            if(canMove)
            {
                if (context.phase == InputActionPhase.Started) //when button is pressed
                {
                    jumpPressed = true;
                    hasJumped = false;

                }
                if (context.phase == InputActionPhase.Canceled) //when button is not pressed
                {
                    jumpPressed = false;

                }
            }
        }

                //new controller functionss
        private void OnDiceThrow(InputAction.CallbackContext context)
        {
            //old
            GetComponent<DiceMechanics.DiceHolder>().ThrowHeldDice();

            myAnimator.SetTrigger("Throw Dice");
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            myMenuManager.PauseGame(); //set this within script
        }

        //physical functions
        private void Movement()
        {
            //gets and sets movement data
            myAnimator.SetBool("Moving", isMoving);
            xThrow = controllerMovement.x;


            //applies movement
            Vector2 playerVelocity = new Vector2(xThrow * playerBaseSpeed, myRigidbody.velocity.y);
            myRigidbody.velocity = playerVelocity;
        }

        private void JumpForce()
        {
            myRigidbody.velocity += new Vector2(0, playerJumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        private void TouchDetecter()
        {
            if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && myRigidbody.velocity.y == 0) //checkes for ground and prevents wall and double jump
            {
                onLand = true;
            }
            else
            {
                onLand = false;
            }
        }

        private void AdvancedJumpCalculations() //error if jump is spammed then one can do a super jump
        {
            if(onLand)
            {
                cayoteFrames = 0;

                if (!hasJumped && jumpBufferFrames < jumpBufferFramesTotal)
                {
                    JumpForce();
                    jumpBufferFrames = jumpBufferFramesTotal;
                    hasJumped = true;
                }
            }

            if(jumpBufferFrames < 50)
            {
                jumpBufferFrames++;
            }

            if (jumpPressed)
            {
                jumpBufferFrames = 0;

                if (!hasJumped && cayoteFrames < cayoteFramesTotal)
                {
                    if(myRigidbody.velocity.y <= 0)
                    {
                        JumpForce();
                        cayoteFrames = cayoteFramesTotal;
                        hasJumped = true;
                    }
                }
            }

            if(cayoteFrames < 50)
            {
                cayoteFrames++;
            }
        }
        public void PauseMove()
        {
            canMove = false;
            if (myBoxCollider.enabled == true)
            {
                StartCoroutine(PauseReset());
            }
        }

        IEnumerator PauseReset()
        {
            //myBoxCollider.enabled = false;
            yield return new WaitForSeconds(1.5f);
            //myBoxCollider.enabled = true;
            canMove = true;
        }

        //Animation functions
        private void FlipSprite()
        {
            bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

            if (playerHasHorizontalSpeed)
            {
                transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
            }
        }

        private void GroundedAnim()
        {
            myAnimator.SetBool("Land", onLand); //set landing animation
        }

        private void AnimateJump() //figures out jump
        {
            if (Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon)
            {
                myAnimator.SetBool("Jump", true);
            }

            if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                myAnimator.SetBool("Jump", false);
            }
        }

        //setters and getters
        public void ChangeMoveStatus(bool change)
        {
            canMove = change;
        }

        public void SetVelocityForAnimation(float gravity, bool toggleMove)
        {
            canMove = toggleMove;
            myRigidbody.gravityScale = gravity;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
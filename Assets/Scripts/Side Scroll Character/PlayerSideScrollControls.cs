using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Audio;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using UnityEditor;
using System;
using DiceMechanics;


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

        [Header("Idle Anim")]
        [SerializeField] float idleMaxTime = 10f;

        //public
        [HideInInspector] public bool isMoving; //might want to not have this be public

        //private
        Vector2 controllerMovement;
        float xThrow;
        bool canMove;
        bool moveIsBeingPressed = false;
        bool moveAnimCheck;

        bool jumpPressed;
        bool hasJumped;
        int jumpBufferFrames;
        int cayoteFrames;

        bool onLand;

        float idleTimeCount;
        bool idleActive;
        int randomIdle = 0;

        //game specific
        [Header("UI")]
        [SerializeField] UI.MenuManager myMenuManager;
        [Header("Character Attatchments")]
        [SerializeField] Projectile.Gun bernieGun;
        [SerializeField] float chargeRate = 1;
        [SerializeField] float chargeMax;

        float chargeDiceCounter = 0;
        bool chargeDiceActive = false;

        //initializers
        Rigidbody2D myRigidbody;
        Animator myAnimator;
        PlayerInput myPlayerInput;
        BoxCollider2D myBoxCollider;
        PlayerStateManager myPlayerStateManager;
        DiceHolder myDiceHolder;
        NumberCaster myNumberCaster;

        // Start is called before the first frame update
        void Awake()
        {
            myPlayerInput = GetComponent<PlayerInput>();
            myRigidbody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
            myBoxCollider = GetComponent<BoxCollider2D>();
            myPlayerStateManager = GetComponent<PlayerStateManager>();
            myDiceHolder = GetComponent<DiceHolder>();
            myNumberCaster = GetComponent<NumberCaster>();

            //controller actions
            myPlayerInput.actions["jump"].started += OnJump;
            myPlayerInput.actions["jump"].canceled += OnJump;
            myPlayerInput.actions["MoveDetect"].started += OnMoveDetect;
            myPlayerInput.actions["MoveDetect"].canceled += OnMoveDetect;

            //new controller actions
            myPlayerInput.actions["DiceThrow"].started += OnDiceThrow;
            myPlayerInput.actions["DiceThrow"].canceled += OnDiceThrow;
            myPlayerInput.actions["Pause"].started += OnPause;
            myPlayerInput.actions["SpellSelectionUp"].started += OnSpellSelectionUp;
            myPlayerInput.actions["SpellSelectionDown"].started += OnSpellSelectionDown;
            myPlayerInput.actions["SpellActivate"].started += OnSpellActivate;
        }

        void Start()
        {
            canMove = true;
            hasJumped = false;
            idleTimeCount = idleMaxTime;
            idleActive = false;
            jumpBufferFrames = jumpBufferFramesTotal + 1;
            cayoteFramesTotal = cayoteFramesTotal + 1;
            myAnimator.SetBool("CanMove", true);
        }

        // Update is called once per frame
        void Update()
        {
            if(canMove)
            {
                AdvancedJumpCalculations();
            }
            if(chargeDiceActive)
            {
                if(chargeDiceCounter < chargeMax)
                {
                    chargeDiceCounter += chargeRate * Time.deltaTime;

                    //every whole number activate animation/ui element
                }
            }

            IdleAnimationSetter();
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
            if (canMove)
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
            if(context.phase == InputActionPhase.Started)
            {
                moveIsBeingPressed = true;
            }
            if(context.phase == InputActionPhase.Canceled)
            {
                moveIsBeingPressed = false;
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
            if(myDiceHolder.isHoldingDice)
            {
                if (context.phase == InputActionPhase.Started)
                {
                    //build power, stop movement
                    myAnimator.SetTrigger("Charge Dice");
                    chargeDiceCounter = 0;
                    chargeDiceActive = true;
                    myPlayerStateManager.PauseMovement();

                }

                if (context.phase == InputActionPhase.Canceled)
                {
                    GetComponent<DiceMechanics.DiceHolder>().ThrowHeldDice(chargeDiceCounter); //pass power
                    chargeDiceActive = false;
                    myAnimator.SetTrigger("Throw Dice");
                    myPlayerStateManager.ResumeMovement();
                }
            }
        }

        private void OnPause(InputAction.CallbackContext context)
        {
            myMenuManager.PauseGame(); //set this within script
        }

        public void OnSpellSelectionUp(InputAction.CallbackContext context)
        {
            myNumberCaster.MoveSelectionDown();
        }

        public void OnSpellSelectionDown(InputAction.CallbackContext context)
        {
            myNumberCaster.MoveSelectionUp();
        }

        public void OnSpellActivate(InputAction.CallbackContext context)
        {
            myNumberCaster.ActivateCurrentSpell();
        }

        //physical functions
        private void Movement()
        {
            //gets and sets movement data
            xThrow = controllerMovement.x;

            //prevents bernie from moon walkign when both directions are pressed
            if (isMoving && xThrow != 0)
                moveAnimCheck = true;
            else
                moveAnimCheck = false;

            if (canMove)
            {
                myAnimator.SetBool("Moving", moveAnimCheck);
            }

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
            if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) //checkes for ground and prevents wall and double jump
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
            myPlayerStateManager.PauseMovement();

            if (myBoxCollider.enabled == true)
            {
                StartCoroutine(PauseReset());
            }
        }

        IEnumerator PauseReset()
        {
            yield return new WaitForSeconds(1.5f);
            myPlayerStateManager.ResumeMovement();
        }

        //Animation functions
        private void FlipSprite()
        {
            bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

            if(canMove)
            {
                if (playerHasHorizontalSpeed)
                {
                    transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
                }
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

        private void IdleAnimationSetter()
        {
            //need to add gun stuff
            if(canMove && !isMoving && !hasJumped)
            { idleTimeCount -= Time.deltaTime; }
            else { idleTimeCount = idleMaxTime; }

            if (idleTimeCount <= 0)
            {
                if(randomIdle == 0)
                {
                    randomIdle = UnityEngine.Random.Range(1, 4);
                }
                idleActive = true;
                myAnimator.SetInteger("AfkNum", randomIdle);
                myAnimator.SetBool("AFK", idleActive);
            }
            else 
            {
                idleActive = false;
                myAnimator.SetBool("AFK", idleActive);
                randomIdle = 0;
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

        public void SetMovementState(bool currentState)
        {
            canMove = currentState;
            myAnimator.SetBool("CanMove", currentState);
            if(!currentState)
                FindObjectOfType<AudioManager>().Stop("Bernie Feet");

            if (moveIsBeingPressed)
                isMoving = true;
        }

        public void ResetIdleTime()
        {
            idleTimeCount = idleMaxTime;
        }

        public bool GetDiceThrowActive()
        {
            return chargeDiceActive;
        }

        public float GetDicePowerLevel()
        {
            return chargeDiceCounter;
        }

        public bool GetMoveStatusAnim() //for animations child under the main object
        {
            return moveAnimCheck;
        }

        public bool GetIdleStatusAnim()
        {
            return idleActive;
        }
    }
}
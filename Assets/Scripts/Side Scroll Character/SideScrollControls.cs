using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

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

        [SerializeField] bool canMove;

        //private
        Rigidbody2D myRigidbody;
        Animator myAnimator;
        PlayerInput myPlayerInput;
        BoxCollider2D myBoxCollider;

        Vector2 controllerMovement;

        float xThrow;

        bool isMoving;
        bool isJumping;

        // Start is called before the first frame update
        void Awake()
        {
            //initializers
            myPlayerInput = GetComponent<PlayerInput>();
            myRigidbody = GetComponent<Rigidbody2D>();
            myAnimator = GetComponent<Animator>();
            myBoxCollider = GetComponent<BoxCollider2D>();

            //controller actions
            myPlayerInput.actions["jump"].started += OnJump;
            myPlayerInput.actions["jump"].canceled += OnJump;
            myPlayerInput.actions["MoveDetect"].started += OnMoveDetect;
            myPlayerInput.actions["MoveDetect"].canceled += OnMoveDetect;

            canMove = true;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //movement
            Movement();
            FallGravity();

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
            }

            if (context.phase == InputActionPhase.Canceled)
            {
                isMoving = false;
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

                if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
                {
                    myAnimator.SetTrigger("Land");
                }
            }
        }

        //jumping
        public void OnJump(InputAction.CallbackContext context)
        {
            //detects the input properly
            if(context.phase == InputActionPhase.Started)
            {
                isJumping = true;
            }
            if(context.phase == InputActionPhase.Canceled)
            {
                isJumping = false;
            }
            //prevents multi jump
            if (!myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || !isJumping)
            {
                return;
            }
            
            

            myRigidbody.velocity += new Vector2(0f, playerJumpPower);
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

        //new
        public void SetMove()
        {
            canMove = false;
            if(myBoxCollider.enabled == true)
            {
                StartCoroutine(ColliderShutdown());
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
            
        }
    }
}

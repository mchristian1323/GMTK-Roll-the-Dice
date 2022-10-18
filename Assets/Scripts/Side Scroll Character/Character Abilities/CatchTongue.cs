using UnityEngine;
using UnityEngine.InputSystem;
using DiceMechanics;
using System.Collections;

namespace SideScrollControl.CharacterAbilities
{
    public class CatchTongue : MonoBehaviour
    {
        [Header("Objects")]
        [SerializeField] GameObject tongueObject;
        [SerializeField] GameObject tongueRotation;

        [Header("Tongue Stats")]
        [SerializeField] float tongueSpeed = 10f;
        [SerializeField] float rotationSpeed = 50f;
        [SerializeField] float diceCatchDelayCounter = 3f;

        [Header("Rotation")]
        [SerializeField] LayerMask diceMask;

        //serialized
        PlayerInput myPlayerInput;
        TongueRenderer myTongueRenderer;
        DiceHolder myDiceHolder;

        //private
        Transform diceTarget;

        bool findDice;

        float diceCatchDelay;

        //need to stop spamming
        //need to fix aim
        //need to animate
        //need to make visual and audio signals on successful catch

        private void Awake()
        {
            myPlayerInput = GetComponent<PlayerInput>();

            myPlayerInput.actions["Tongue"].started += TongueActivate;
        }

        private void Start()
        {
            myTongueRenderer = GetComponentInChildren<TongueRenderer>();
            myDiceHolder = GetComponent<DiceHolder>();

            diceCatchDelay = 0f;
        }

        private void Update()
        {
            if(diceCatchDelay > 0f)
            {
                diceCatchDelay -= Time.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            if (diceTarget == null)
                return;

            Vector3 dir;
            Quaternion lookRotation;

            if(transform.localScale.x > 0)
            {
                dir = diceTarget.position - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                tongueRotation.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                dir = diceTarget.position - transform.position;
                var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 180f;
                lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                tongueRotation.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }
        }

        public void TongueActivate(InputAction.CallbackContext context)
        {
            if(!myDiceHolder.GetDiceHoldInfo() && diceCatchDelay <= 0f) //switch to false
            {
                FindDice();
                diceCatchDelay = diceCatchDelayCounter;
            }
        }

        private void FindDice()
        {
            var targets = Physics2D.OverlapCircle(transform.position, 100f, diceMask);
            diceTarget = targets.GetComponent<Transform>();

            myTongueRenderer.RenderTongue(tongueSpeed, tongueObject.transform.position);

            float distance = Vector2.Distance(diceTarget.transform.position, transform.position);
            if(distance <= 3f)
            {
                StartCoroutine(CatchDelay());
            }
        }

        IEnumerator CatchDelay()
        {
            yield return new WaitForSeconds(0.1f);
            CatchThatDice();
            myTongueRenderer.TongueCancel();
        }

        private void CatchThatDice()
        {
            GetComponent<DiceHolder>().HoldCheck();
        }

        public void SetFindDice(bool state)
        {
            findDice = state;
        }


        //at the peak of the tongue lash the dice needs to be caught if within a certain radius
            //delay it until the peak
            //if dice is detected snap it to the character or call the dice functionallity

            //possible add a snapp animation where the tonge and the dice have a stop delay and then snap
    }
}

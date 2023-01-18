using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideScrollControl.CharacterAbilities
{
    public class Tongue : MonoBehaviour
    {
        [SerializeField] LayerMask grappleMask;
        [SerializeField] float maxDistance = 10f;
        [SerializeField] float grappleSpeed = 10f;
        [SerializeField] float shootSpeed = 10f;

        bool isGrappling = false;
        [HideInInspector] public bool retracting = false;

        Vector3 direction;
        Vector2 target;

        LineRenderer myLineRenderer;

        //new tongue-> when the button is pressed, the tounge will travel towards the dice
            //once it hits a certain range (possible circle mesurment spawn anim) it checks to see if the dice is also in that range and if so retract the dice towards berny along with the tounge at the same speed
            //if no dice then just retract the tounge

        //code order-
        //retract dice
        //retract dice at range
        //tounge anim
        //retract dice after tounge reaches total length
        //tweek

        private void Start()
        {
            myLineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if(retracting)
            {
                Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);

                transform.position = grapplePos;

                myLineRenderer.SetPosition(0, transform.position);

                if(Vector2.Distance(transform.position, target) < 1f)
                {
                    retracting = false;
                    isGrappling = false;
                    myLineRenderer.enabled = false;
                }
            }
        }

        public void TongueGrapple(float lookDirection)
        {
            if (!isGrappling)
            {
                direction = transform.position;
                //Debug.Log(direction);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, grappleMask);

                if (hit.collider != null)
                {
                    isGrappling = true;
                    target = hit.point;
                    myLineRenderer.enabled = true;
                    myLineRenderer.positionCount = 2;

                    StartCoroutine(GrappleTime());
                }
                else
                {
                    isGrappling = true;
                    target = hit.point;
                    myLineRenderer.enabled = true;
                    myLineRenderer.positionCount = 2;

                    StartCoroutine(EmptyGrappleTime());
                }
            }
        }

        IEnumerator EmptyGrappleTime()
        {
            float time = 10;

            myLineRenderer.SetPosition(0, transform.position);
            myLineRenderer.SetPosition(1, transform.position);

            Vector2 newPos;

            for (float t = 0; t < time; t += shootSpeed * Time.deltaTime)
            {
                newPos = Vector2.Lerp(transform.position, direction, t / time);
                myLineRenderer.SetPosition(0, transform.position);
                myLineRenderer.SetPosition(1, newPos);
                yield return null;
            }

            isGrappling = false;
            myLineRenderer.enabled = false;
        }

        IEnumerator GrappleTime()
        {
            float time = 10;

            myLineRenderer.SetPosition(0, transform.position);
            myLineRenderer.SetPosition(1, transform.position);

            Vector2 newPos;

            for (float t = 0; t < time; t += shootSpeed * Time.deltaTime)
            {
                newPos = Vector2.Lerp(transform.position, target, t / time);
                myLineRenderer.SetPosition(0, transform.position);
                myLineRenderer.SetPosition(1, newPos);
                yield return null;
            }

            myLineRenderer.SetPosition(1, target);
            retracting = true;
        }
    }
}

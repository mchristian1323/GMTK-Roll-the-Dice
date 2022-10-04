using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideScrollControl.CharacterAbilities
{
    public class TongueRenderer : MonoBehaviour
    {
        LineRenderer myLineRenderer;

        //when activate tongue
        //turn on line renderer, pass through points, and render
        //have an object on berny travel from her to the dice direction max position
        //once it hits it activates catch and then goes back to berny
        //when it get to berny it shuts off script and turns off line renderer

        bool isGrappling;
        bool retracting;

        Vector2 retractNewPos;
        Vector2 retractCurrentPos;

        private void Awake()
        {
            myLineRenderer = GetComponent<LineRenderer>();
        }

        public void RenderTongue(float grappleSpeed, Vector2 target)
        {
            isGrappling = true;
            myLineRenderer.enabled = true;
            myLineRenderer.positionCount = 2;

            StartCoroutine(TongueGrapple(grappleSpeed, target));
        }

        IEnumerator TongueGrapple(float grappleSeed, Vector2 target)
        {
            float t = 0;
            float time = 10;
            myLineRenderer.SetPosition(0, transform.position);
            myLineRenderer.SetPosition(1, transform.position);

            Vector2 newPos;

            for(; t < time; t += grappleSeed + Time.deltaTime)
            {
                newPos = Vector2.Lerp(transform.position, target, t);
                myLineRenderer.SetPosition(0, transform.position);
                myLineRenderer.SetPosition(1, newPos);
                yield return null;
            }

            myLineRenderer.SetPosition(1, target);
            retracting = true;
            retractCurrentPos = target;
        }

        private void Update()
        {
            if(retracting)
            {
                for (float t = 0; t < 10; t += 10 + Time.deltaTime)
                {
                    retractNewPos = Vector2.Lerp(retractCurrentPos, transform.position, t);
                    myLineRenderer.SetPosition(0, transform.position);
                    myLineRenderer.SetPosition(1, retractNewPos);
                }
                myLineRenderer.SetPosition(1, transform.position);
                retracting = false;
                isGrappling = false;
                myLineRenderer.enabled = false;
            }
        }


        public bool GetGrappleStatus()
        {
            return isGrappling;
        }
    }
}

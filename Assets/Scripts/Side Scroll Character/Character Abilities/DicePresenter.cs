using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideScrollControl
{
    public class DicePresenter : MonoBehaviour
    {
        SpriteRenderer mySpritRenderer;
        // Start is called before the first frame update
        void awake()
        {
            mySpritRenderer = GetComponent<SpriteRenderer>();
            mySpritRenderer.enabled = false;
        }

        public void DisplayDice(Sprite sprite)
        {
            StartCoroutine(DelayDislpay(sprite));
        }   
        
        IEnumerator DelayDislpay(Sprite sprite)
        {
            mySpritRenderer.enabled = true;
            mySpritRenderer.sprite = sprite;
            yield return new WaitForSeconds(4f);
            mySpritRenderer.enabled = false;
        }
    }
}

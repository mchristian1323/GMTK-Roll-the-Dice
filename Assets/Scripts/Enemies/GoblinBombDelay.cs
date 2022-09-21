using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class GoblinBombDelay : MonoBehaviour
    {
        public void DelayGoblin()
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<AggroGoblin>().enabled = false;
            StartCoroutine(DelayCounter());
        }

        IEnumerator DelayCounter()
        {
            yield return new WaitForSeconds(.5f);
            GetComponent<AggroGoblin>().enabled = true;
            GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }
}

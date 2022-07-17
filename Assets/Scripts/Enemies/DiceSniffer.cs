using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class DiceSniffer : MonoBehaviour
    {
        [SerializeField] AggroGoblin myAggroGoblin;
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.tag == "Dice")
            {
                myAggroGoblin.SetCurrentTarget(collision.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Dice")
            {
                myAggroGoblin.SetPlayerTarget();
            }
        }
    }
}

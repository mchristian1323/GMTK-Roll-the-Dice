using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Parascope : MonoBehaviour
    {
        [SerializeField] EnemyBaseMovement submarine;
        [SerializeField] BoxCollider2D myBoxCollider;

        private void OnTriggerExit2D(Collider2D collision)
        {
            submarine.FlipEnemyFacing();
        }
    }
}

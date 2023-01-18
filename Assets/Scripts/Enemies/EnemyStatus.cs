using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyStatus : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] float health = 100;
        [SerializeField] float damage = 10;

        public void TakeDamage(float damage)
        {
            health -= damage;

            if(health <= 0)
            {
                //dead
                Debug.Log("Dead");
            }
        }

        //getters and setters
        public float GetEnemyDamage()
        {
            return damage;
        }
    }
}

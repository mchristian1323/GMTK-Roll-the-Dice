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

        public float GetEnemyDamage()
        {
            return damage;
        }
    }
}

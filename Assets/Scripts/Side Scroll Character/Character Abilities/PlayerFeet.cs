using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideScrollControl.Abilities
{
    public class PlayerFeet : MonoBehaviour
    {
        [SerializeField] GameObject player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Soft Enemy")
            {
                collision.gameObject.GetComponent<Enemy.EnemyBaseMovement>().BopEnemy();
                player.GetComponent<SideScrollControls>().LaunchPlayer();
            }

            if(collision.tag == "Goblin")
            {
                collision.gameObject.GetComponent<Enemy.AggroGoblin>().BopEnemy();
                player.GetComponent<SideScrollControls>().LaunchPlayer();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectable
{
    /// <summary>
    /// place this on the basic collectalbe. make sure the tags are in align
    /// </summary>
    public class BasicCollectable : MonoBehaviour
    {
        [SerializeField] int value = 1;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Player")
            {
                collision.gameObject.GetComponent<CollectionBank>().AddCoins(value);
                //play sound
                //destruction animation
                Destroy(gameObject);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectable
{
    /// <summary>
    /// This goes on the player to store the collectables and to destribute them. this could be tied into or replaced by the
    /// inventory system.
    /// To add colectables, repeat the current functions for said collectables. the get coins is for display of amount of coins
    /// </summary>
    public class CollectionBank : MonoBehaviour
    {
        //collectable storage/public
        [SerializeField] int coins;

        public void AddCoins(int coinAmount)
        {
            coins += coinAmount;
        }

        public void SubtractCoins(int coinAmount)
        {
            coins -= coinAmount;
        }

        public int GetCoins()
        {
            return coins;
        }
    }
}

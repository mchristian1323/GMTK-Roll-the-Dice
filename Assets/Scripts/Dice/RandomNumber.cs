using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dice
{
    public class RandomNumber : MonoBehaviour
    {
        [SerializeField] int generatedNumber;

        public int RandomGenerate()
        {
            generatedNumber = Random.Range(1, 7);

            return generatedNumber;
        }
    }
}

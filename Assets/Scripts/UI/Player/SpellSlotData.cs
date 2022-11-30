using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Player
{
    public class SpellSlotData : MonoBehaviour
    {
        int originalPlacing;

        //setters and getters
        public void SetOriginalPlacing(int num)
        {
            originalPlacing = num;
        }

        public int GetOriginalPlacing()
        {
            return originalPlacing;
        }
    }
}

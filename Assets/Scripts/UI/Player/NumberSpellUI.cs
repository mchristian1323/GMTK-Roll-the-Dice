using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceMechanics;

namespace UI.Player
{
    public class NumberSpellUI : MonoBehaviour
    {
        Transform numberSlot;

        // Start is called before the first frame update
        private void Awake()
        {
            numberSlot = transform.Find("Number Slot");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

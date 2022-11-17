using UnityEngine;

namespace UI.Player
{
    public class AmmoSlotData : MonoBehaviour
    {
        int number = 0;

        public void SetNumber(int num)
        {
            number = num;
        }

        public int GetNumber()
        {
            return number;
        }
    }
}

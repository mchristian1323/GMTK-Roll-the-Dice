using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceMechanics.DiceEffects
{
    public class EffectObjectScript : MonoBehaviour
    {
        [SerializeField] UniqueEffect thisUniqueEffect;
        // Start is called before the first frame update
        void Start()
        {
            thisUniqueEffect.NewEffect();
            StartCoroutine(Timer());
        }

        IEnumerator Timer()
        {
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;

namespace DiceMechanics.DiceEffects
{
    public class EffectObjectScript : MonoBehaviour
    {
        [SerializeField] UniqueEffect thisUniqueEffect;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Timer());
        }

        IEnumerator Timer()
        {
            thisUniqueEffect.NewEffect();
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;

namespace ModificationFiles
{
    public class EffectDisabler : MonoBehaviour
    {
        [SerializeField] private float _delay;

        private WaitForSeconds _waitForSeconds;

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_delay);
            StartCoroutine(SetActiveChanged());
        }

        private IEnumerator SetActiveChanged()
        {
            yield return _waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}
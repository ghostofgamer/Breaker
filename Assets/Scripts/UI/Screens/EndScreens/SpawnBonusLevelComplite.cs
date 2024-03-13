using System.Collections;
using UnityEngine;

namespace UI.Screens.EndScreens
{
    public class SpawnBonusLevelComplite : MonoBehaviour
    {
        [SerializeField] private Transform[] _bonuses;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.15f);
    
        public void StartFlightBonuses()
        {
            StartCoroutine(ActivatedBonus());
        }
    
        private IEnumerator ActivatedBonus()
        {
            for (int i = 0; i < _bonuses.Length; i++)
            {
                _bonuses[i].gameObject.SetActive(true);
                yield return _waitForSeconds;
            }
        }
    }
}
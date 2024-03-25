using UnityEngine;

namespace Levels
{
    public class ColliderController : MonoBehaviour
    {
        [SerializeField] private Level[] _levels;

        public void SetValue(bool enabledValue)
        {
            foreach (var level in _levels)
                level.GetComponent<BoxCollider>().enabled = enabledValue;
        }
    }
}
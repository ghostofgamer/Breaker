using UnityEngine;

namespace Levels
{
    public class ColliderToggle : MonoBehaviour
    {
        [SerializeField] private Level[] _levels;

        public void ColliderActivation()
        {
            foreach (var level in _levels)
                level.Activation();
        }

        public void ColliderDeactivation()
        {
            foreach (var level in _levels)
                level.Deactivation();
        }
    }
}
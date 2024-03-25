using Enum;
using UnityEngine;

namespace ModificationFiles
{
    public abstract class Effect : MonoBehaviour
    {
        [SerializeField] private GameObject _effect;
        [SerializeField] private BuffType _buffType;

        public BuffType BuffType => _buffType;

        public void Destroy()
        {
            _effect.SetActive(true);
            _effect.transform.parent = null;
            gameObject.SetActive(false);
        }
    }
}
using PlayerFiles.PlatformaContent;
using SaveAndLoad;
using UnityEngine;

namespace Skins
{
    public class SkinPlatformLoader : MonoBehaviour
    {
        [SerializeField] private Load _load;
        [SerializeField] private GameObject[] _skins;

        private int _startIndex = 0;

        private void Start()
        {
            int index = _load.Get(Save.ActiveCapsuleIndex, _startIndex);

            _skins[index ].SetActive(true);
        }
        
        
    }
}
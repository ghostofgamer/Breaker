using GameScene.BallContent;
using SaveAndLoad;
using UnityEngine;

namespace Skins
{
    public class SkinLoader : MonoBehaviour
    {
        [SerializeField] private Load _load;
        [SerializeField] private GameObject[] _skins;
        [SerializeField] private PortalTeleporterBall _portalTeleporterBall;

        private MeshRenderer _meshRenderer;
        private int _skinBallIndex;
        private int _startIndex = 0;

        private void Start()
        {
            _skinBallIndex = _load.Get(Save.SkinBall, _startIndex);
            _skins[_skinBallIndex].SetActive(true);
            _portalTeleporterBall.Init(_skins[_skinBallIndex].GetComponentInChildren<ParticleSystem>());
        }
    }
}
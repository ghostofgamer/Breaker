using GameScene.BallContent;
using SaveAndLoad;
using UnityEngine;

namespace Skins
{
    public class SkinLoader : MonoBehaviour
    {
        private const string SkinBall = "SkinBall";

        [SerializeField] private Load _load;
        [SerializeField] private GameObject[] _skins;
        [SerializeField] private PortalTeleporterBall _portalTeleporterBall;
        [SerializeField] private ParticleSystem[] _skinParticleSystems;

        private int _skinBallIndex;
        private int _startIndex = 0;

        private void Start()
        {
            _skinBallIndex = _load.Get(SkinBall, _startIndex);
            _skins[_skinBallIndex].SetActive(true);
            _portalTeleporterBall.Init(_skinParticleSystems[_skinBallIndex]);
        }
    }
}
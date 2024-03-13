using GameScene.BallContent;
using SaveAndLoad;
using UnityEngine;

namespace Skins
{
    public class SkinLoader : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private Material[] _skinsBall;
        [SerializeField] private Load _load;
        [SerializeField] private GameObject[] _skins;
        [SerializeField] private BallTrigger _ballTrigger;

        private MeshRenderer _meshRenderer;
        private int _skinBallIndex;
        private int _startIndex = 0;

        private void Start()
        {
            // _meshRenderer = _ball.GetComponent<MeshRenderer>();
            _skinBallIndex = _load.Get(Save.SkinBall, _startIndex);
            _skins[_skinBallIndex].SetActive(true);
            _ballTrigger.Init(_skins[_skinBallIndex].GetComponent<MeshRenderer>());
            // LoadSkin();
        }

        public void LoadSkin()
        {
            _meshRenderer.material = _skinsBall[_skinBallIndex];
        }
    }
}
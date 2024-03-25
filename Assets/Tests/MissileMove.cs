using GameScene.BallContent;
using UnityEngine;

namespace Tests
{
    public class MissileMove : MonoBehaviour
    {
        [SerializeField] private BallMover _ballMover;

        private void Update()
        {
            transform.position = _ballMover.transform.position;
        }
    }
}
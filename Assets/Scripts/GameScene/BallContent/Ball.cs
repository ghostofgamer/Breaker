using PlayerFiles;
using PlayerFiles.PlatformaContent;
using Statistics;
using UnityEngine;
using UnityEngine.Events;

namespace GameScene.BallContent
{
    public class Ball : Player
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private PlatformaMover _platformaMover;
        [SerializeField] private Transform _enviropment;

        private BallMover _ballMover;
        private bool _isWin;
        private Rigidbody _rigidbody;

        public bool IsMoving { get; private set; }
        public Transform StartPosition => _startPosition;
        public PlatformaMover PlatformaMover => _platformaMover;

        public event UnityAction Die;

        private void Start()
        {
            _ballMover = GetComponent<BallMover>();
            _rigidbody = GetComponent<Rigidbody>();
            StopMove();
        }

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroy += StopMove;
            _brickCounter.AllBrickDestroy += SetParent;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroy -= StopMove;
            _brickCounter.AllBrickDestroy -= SetParent;
        }

        private void Update()
        {
            if (!IsMoving && !_isWin)
            {
                var position = _platformaMover.transform.position;
                transform.position = new Vector3(position.x, position.y,
                    position.z + 3f);
            }
        }

        public void StopMove()
        {
            IsMoving = false;
            _ballMover.enabled = false;
            _rigidbody.isKinematic = true;
        }

        private void SetParent()
        {
            _isWin = true;
            transform.parent = _enviropment;
        }

        public void SetMove(bool flag, float directionX)
        {
            IsMoving = flag;
            _ballMover.enabled = flag;
            _rigidbody.isKinematic = !flag;
            _ballMover.SetStartDirection(new Vector3(directionX, 0, 1).normalized);
        }

        protected void Lost()
        {
            Die?.Invoke();
        }
    }
}
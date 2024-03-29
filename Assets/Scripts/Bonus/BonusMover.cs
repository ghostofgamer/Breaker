using GameScene;
using UnityEngine;

namespace Bonus
{
    public class BonusMover : Mover
    {
        private Vector3 _direction;
        private float _minAngle = -15f;
        private float _maxAngle = 15f;

        protected override void Start()
        {
            base.Start();
            float angle = Random.Range(_minAngle, _maxAngle);
            _direction = Quaternion.AngleAxis(angle, Vector3.up) * -Vector3.forward;
        }

        protected override void Update()
        {
            transform.position += _direction * (Speed * Time.deltaTime);
            base.Update();
        }

        protected override void JumpActivation()
        {
            float newAngle = Random.Range(_minAngle, _maxAngle);
            _direction = Quaternion.AngleAxis(newAngle, Vector3.up) * -Vector3.forward;
            base.JumpActivation();
        }
    }
}
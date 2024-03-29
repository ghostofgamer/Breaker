using UnityEngine;

namespace GameScene
{
    public class FlyBonus : MonoBehaviour
    {
        private float _timeFlying = 1;
        private float _elapsedTime = 0;
        private float _speed = 10f;

        private void Update()
        {
            if (_elapsedTime >= _timeFlying)
                gameObject.SetActive(false);

            _elapsedTime += Time.deltaTime;
            transform.Translate(-Vector3.forward * (_speed * Time.deltaTime));
        }
    }
}
using UnityEngine;

namespace PlayerFiles
{
    public class MousePositionController : MonoBehaviour
    {
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = false;
        }

        private void Update()
        {
            SetActive();
        }

        private void SetActive()
        {
            if (transform.position.x > _maxX || transform.position.x < _minX || transform.position.z > _maxZ ||
                transform.position.z < _minZ)
            {
                if (!_spriteRenderer.enabled)
                    return;

                _spriteRenderer.enabled = false;
            }
            else
            {
                if (_spriteRenderer.enabled)
                    return;

                _spriteRenderer.enabled = true;
            }
        }
    }
}
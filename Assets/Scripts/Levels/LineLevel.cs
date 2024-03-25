using UnityEngine;

namespace Levels
{
    public class LineLevel : MonoBehaviour
    {
        public ParticleSystem particleSystem1;
        public ParticleSystem particleSystem2;
        private LineRenderer _lineRenderer;

        void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        void Update()
        {
            if (particleSystem1 != null && particleSystem2 != null)
            {
                _lineRenderer.SetPosition(0, particleSystem1.transform.position);
                _lineRenderer.SetPosition(1, particleSystem2.transform.position);
            }
        }
    }
}
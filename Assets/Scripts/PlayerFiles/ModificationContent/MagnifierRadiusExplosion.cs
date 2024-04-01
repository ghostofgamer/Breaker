using System.Collections.Generic;
using Bricks;
using UnityEngine;

namespace PlayerFiles.ModificationContent
{
    public class MagnifierRadiusExplosion : MonoBehaviour
    {
        [SerializeField] private Transform _bricksContainer;

        private float _factor = 1.65f;
        private List<BrickExplosion> _brickExplosions;

        private void Awake()
        {
            _brickExplosions = new List<BrickExplosion>();

            for (int i = 0; i < _bricksContainer.childCount; i++)
            {
                Transform child = _bricksContainer.GetChild(i);
                BrickExplosion brickExp = child.GetComponent<BrickExplosion>();

                if (brickExp != null && !child.GetComponent<BrickCoordinator>().IsEternal && child.gameObject.activeSelf)
                    _brickExplosions.Add(brickExp);
            }
        }

        private void Start()
        {
            foreach (var brick in _brickExplosions)
            {
                float radius = brick.Radius;
                radius *= _factor;
                brick.SetRadius(radius);
            }
        }
    }
}
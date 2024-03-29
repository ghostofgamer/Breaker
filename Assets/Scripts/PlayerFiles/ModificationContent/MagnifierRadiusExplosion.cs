using System.Collections.Generic;
using System.Linq;
using Bricks;
using UnityEngine;

namespace PlayerFiles.ModificationContent
{
    public class MagnifierRadiusExplosion : MonoBehaviour
    {
        [SerializeField] private Transform _bricksContainer;

        private List<Transform> _filtredBrick;
        private float _factor = 1.65f;

        private void Start()
        {
            List<Transform> bricksList = new List<Transform>();
            _filtredBrick = new List<Transform>();

            for (int i = 0; i < _bricksContainer.childCount; i++)
                bricksList.Add(_bricksContainer.GetChild(i));
            
            _filtredBrick = bricksList
                .Where(p => p.gameObject.GetComponent<BrickExplosion>() &&
                            !p.gameObject.GetComponent<Brick>().IsEternal &&
                            p.gameObject.activeSelf == true).ToList();

            foreach (var brick in _filtredBrick)
            {
                BrickExplosion brickExp = brick.GetComponent<BrickExplosion>();
                float radius = brickExp.Radius;
                radius *= _factor;
                brickExp.SetRadius(radius);
            }
        }
    }
}
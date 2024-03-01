using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporterBall : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ParticleSystem _missileEffect;
    [SerializeField] private float _xMinPosition;
    [SerializeField] private float _xMaxPosition;
    [SerializeField] private float _zMaxPosition;
    [SerializeField] private float _zMinPosition;
    
    public void TeleportBall()
    {
        if (transform.position.x > _xMaxPosition)
        {
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
            _missileEffect.gameObject.SetActive(false);
            transform.position = new Vector3(_xMinPosition, transform.position.y, transform.position.z);
            _missileEffect.gameObject.SetActive(true);
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
        }

        if (transform.position.x < _xMinPosition)
        {
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
            _missileEffect.gameObject.SetActive(false);
            transform.position = new Vector3(_xMaxPosition, transform.position.y, transform.position.z); 
            _missileEffect.gameObject.SetActive(true);
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
        }

        if (transform.position.z < _zMinPosition)
        {
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
            _missileEffect.gameObject.SetActive(false);
            transform.position = new Vector3(transform.position.x, transform.position.y, _zMaxPosition);
            _missileEffect.gameObject.SetActive(true);
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
        }

        if (transform.position.z > _zMaxPosition)
        {
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
            _missileEffect.gameObject.SetActive(false);
            transform.position = new Vector3(transform.position.x, transform.position.y, _zMinPosition);
            _missileEffect.gameObject.SetActive(true);
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
        }
    }
}

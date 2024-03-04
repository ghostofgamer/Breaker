using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallTrigger : MonoBehaviour
{
    [SerializeField] private BallMover _ballMover;

    // [SerializeField] private Transform _enviropment;
    public float platformOffset = 3f;
    public float sphereRadius = 0.5f;
    public LayerMask platformLayer;
    public event UnityAction Dying;

    private bool _isHit;
    private bool _isBackHit;


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Bourder bourder))
        {
            Dying?.Invoke();
            gameObject.SetActive(false);
            GetComponent<Ball>().StopMove();
            // transform.parent = _enviropment;
        }
    }


    private void OnDrawGizmos()
    {
        float maxDistance = 1.5f;
        RaycastHit hit;

        Vector3 predictedPosition = transform.position + _ballMover.Direction * _ballMover.speed * Time.deltaTime;

        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, _ballMover.Direction, out hit,
            maxDistance, platformLayer);

        bool isBackHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, -_ballMover.Direction,
            out hit,
            maxDistance, platformLayer);


        if (isHit)
        {
            Gizmos.color = Color.red;
            // Debug.Log("Расстояние " + hit.distance);


            Vector3 Reflect = Vector3.Reflect(_ballMover.Direction, hit.normal);
            // _ballMover.SetDirection(Reflect);
            // Debug.Log("толкаемся");

            Gizmos.DrawRay(transform.position, _ballMover.Direction * hit.distance);
            Gizmos.DrawWireSphere(transform.position + _ballMover.Direction * hit.distance, transform.lossyScale.x / 2);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, _ballMover.Direction * maxDistance);
        }


        if (isBackHit)
        {
            Gizmos.color = Color.red;
            // Debug.Log("Расстояние " + hit.distance);


            Vector3 Reflect = Vector3.Reflect(-_ballMover.Direction, hit.normal);
            // _ballMover.SetDirection(Reflect);
            // Debug.Log("толкаемся");

            Gizmos.DrawRay(transform.position, -_ballMover.Direction * hit.distance);
            Gizmos.DrawWireSphere(transform.position + -_ballMover.Direction * hit.distance,
                transform.lossyScale.x / 2);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, -_ballMover.Direction * maxDistance);
        }
    }

    public void CheckPlatformCollision()
    {
        float mouse = Input.GetAxis("Mouse X") * 2;
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 New = new Vector3(mouse, 0, mouseY).normalized;

        float maxDistance = 1.5f;
        RaycastHit hit;

        Vector3 predictedPosition = transform.position + _ballMover.Direction * _ballMover.speed * Time.deltaTime;

        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, _ballMover.Direction, out hit,
            maxDistance, platformLayer);

        bool isBackHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, -_ballMover.Direction,
            out hit,
            maxDistance, platformLayer);

        if (Physics.SphereCast(transform.position, transform.lossyScale.x / 2, _ballMover.Direction, out hit,
            maxDistance, platformLayer))
        {
            if (hit.collider.gameObject.TryGetComponent<PlatformaMover>(out PlatformaMover PlatformaMover))
            {
                // Debug.Log("HIT");
                ChangeDirection(New, hit);
            }
        }

        if (Physics.SphereCast(transform.position, transform.lossyScale.x / 2, -_ballMover.Direction, out hit,
            maxDistance, platformLayer))
        {
            if (hit.collider.gameObject.TryGetComponent<PlatformaMover>(out PlatformaMover зlatformaMover))
            {
                // Debug.Log("BackHit");
                ChangeDirection(New, hit);
                // Debug.Log("NEWDIRECTION" + _ballMover.Direction);
            }
        }


        // ChangeDirection(New,hitColliders[i]);
    }

    public void Checkplatform()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Ray backray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;
        float mouse = Input.GetAxis("Mouse X") * 2;

        float mouseY = Input.GetAxis("Mouse Y");
/*if (Input.GetAxis("Mouse Y") * 2 > 0.3)
    Debug.Log("Удвоение" + Input.GetAxis("Mouse Y") * 2);*/

/*
if (Input.GetAxis("Mouse Y") > 0.3)
    Debug.Log("Просто " + Input.GetAxis("Mouse Y"));*/

/*Debug.Log("Mouse Direction: " + mouse);
Debug.Log("Mouse Direction: " + new Vector3(mouse, 0, 0).normalized);*/
        Vector3 New = new Vector3(mouse, 0, mouseY).normalized;
        /*if (Physics.Raycast(ray, out hit, _ballMover.RayLength))
        {
            if (hit.collider.gameObject.TryGetComponent<PlatformController>(out var platformController) ||
                hit.collider.gameObject.TryGetComponent<PlatformaMover>(out PlatformaMover testPlatformaMover) ||
                hit.collider.gameObject.TryGetComponent<MirrorPlatformaMover>(
                    out MirrorPlatformaMover mirrorPlatformaMover))
            {
                ChangeDirection(New, hit);
            }
        }*/

        if (Physics.Raycast(backray, out hit, _ballMover.RayLength))
        {
            if (hit.collider.gameObject.TryGetComponent(out PlatformController platformController) ||
                hit.collider.gameObject.TryGetComponent(out PlatformaMover testPlatformaMover))
            {
                ChangeDirection(New, hit);
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * _ballMover.RayLength, Color.red);
        Debug.DrawRay(backray.origin, backray.direction * _ballMover.RayLength, Color.green);
    }

    private void ChangeDirection(Vector3 New, RaycastHit hit)
    {
        GetComponent<MeshRenderer>().enabled = false;
        Vector3 platformUp = hit.transform.forward;
        // Debug.Log("PlatformUP " + platformUp);
        Vector3 newPosition = hit.point + platformUp * platformOffset; // Новая позиция над платформой
        // transform.position = newPosition;
        GetComponent<MeshRenderer>().enabled = true;
// _direction = Vector3.Reflect(_direction, hit.normal);

        Vector3 Reflect = Vector3.Reflect(_ballMover.Direction, hit.normal);
        Vector3 NEWREFLECT = new Vector3(Reflect.x, Reflect.y, 1).normalized;
        // Debug.Log("Reflect " + Reflect);
        if (New.z > 0.5)
        {
            _ballMover.SetDirection(new Vector3(Reflect.x, Reflect.y, Reflect.z + New.z).normalized);
            Vector3 direction = new Vector3(Reflect.x, Reflect.y, NEWREFLECT.z + New.z).normalized;
            // Debug.Log("DirectionZZZ " + direction);
            ;
            _ballMover.FastSpeed();
        }
        else
        {
            // Debug.Log("ELSE - Z " + NEWREFLECT);
            _ballMover.SetDirection(NEWREFLECT);
        }

        if (New.x > 0.3 || New.x < -0.3)
        {
            // Debug.Log("X");
            _ballMover.SetDirection(new Vector3(Reflect.x + New.x, Reflect.y, NEWREFLECT.z).normalized);
        }
        else
        {
            // Debug.Log("ELSE - X " + NEWREFLECT);
            _ballMover.SetDirection(NEWREFLECT);
        }
    }
}
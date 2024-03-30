using System.Collections;
using UnityEngine;
using WeaponFiles;

namespace ModificationFiles.BuffsFiles
{
    public class Laser : Modification
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Weapon _mirrorPlatformWeapon;
        [SerializeField] private float _timeBetweenShots;

        private float _elapsedTime = 0;
        private bool _isActive = false;

        protected override void Start()
        {
            SetValue(_timeBetweenShots);
        }

        private void Update()
        {
            if (_isActive)
            {
                _elapsedTime += Time.deltaTime;

                if (_elapsedTime >= Duration)
                    _isActive = false;
            }
        }

        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                SetCoroutine(StartCoroutine(OnShoot()));
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Stop();
        }

        private IEnumerator OnShoot()
        {
            _elapsedTime = 0;
            SetActive(true);
            _isActive = true;

            while (_isActive)
            {
                _weapon.Shoot();

                if (_mirrorPlatformWeapon.gameObject.activeSelf)
                    _mirrorPlatformWeapon.Shoot();

                yield return WaitForSeconds;
            }

            Stop();
            Player.DeleteEffect(this);
        }

        private void Stop()
        {
            SetActive(false);
            _isActive = false;
        }
    }
}
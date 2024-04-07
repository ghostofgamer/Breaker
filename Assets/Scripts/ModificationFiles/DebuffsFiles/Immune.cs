using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bricks;
using UnityEngine;

namespace ModificationFiles.DebuffsFiles
{
    public class Immune : Modification
    {
        [SerializeField] private Transform _bricksContainer;

        private List<BrickCoordinator> _bricks;
        private List<BrickCoordinator> _filtredBricks;

        protected override void Awake()
        {
            _filtredBricks = new List<BrickCoordinator>();
            _bricks = new List<BrickCoordinator>();
            FindAllChildren(_bricksContainer);
        }

        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                SetCoroutine(StartCoroutine(OnImmuneBricksActivated()));
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            DisableBricksImmortal();
        }

        private IEnumerator OnImmuneBricksActivated()
        {
            _filtredBricks = _bricks
                .Where(p => p.gameObject.activeSelf == true).ToList();

            EnableBricksImmortal();
            yield return WaitForSeconds;
            DisableBricksImmortal();
            Player.DeleteEffect(this);
        }

        private void EnableBricksImmortal()
        {
            EnableBuffUI();

            foreach (BrickCoordinator brick in _filtredBricks)
                brick.EnableImmortalEffect();
        }

        private void DisableBricksImmortal()
        {
            DisableBuffUI();

            foreach (BrickCoordinator brick in _filtredBricks)
                brick.DisableImmortalEffect();
        }

        private void FindAllChildren(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                BrickCoordinator brickCoordinator = child.GetComponent<BrickCoordinator>();

                if (brickCoordinator != null && !brickCoordinator.IsEternal && child.gameObject.activeSelf)
                    _bricks.Add(brickCoordinator);

                FindAllChildren(child);
            }
        }
    }
}
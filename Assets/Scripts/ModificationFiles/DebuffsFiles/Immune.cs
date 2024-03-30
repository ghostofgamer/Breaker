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

        private List<Brick> _bricks;
        private List<Brick> _filtredBricks;

        private void Awake()
        {
            _filtredBricks = new List<Brick>();
            _bricks = new List<Brick>();

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

            foreach (Brick brick in _filtredBricks)
                brick.EnableImmortalEffect();
        }

        private void DisableBricksImmortal()
        {
            DisableBuffUI();

            foreach (Brick brick in _filtredBricks)
                brick.DisableImmortalEffect();
        }

        private void FindAllChildren(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                Brick brick = child.GetComponent<Brick>();

                if (brick != null && !brick.IsEternal && child.gameObject.activeSelf)
                    _bricks.Add(brick);

                FindAllChildren(child);
            }
        }
    }
}
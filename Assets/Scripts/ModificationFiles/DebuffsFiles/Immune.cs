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

        private List<Transform> _bricks;
        private List<Transform> _filtredBricks;

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
            ChangeBricksImmortal(false);
        }

        private IEnumerator OnImmuneBricksActivated()
        {
            SetList();
            ChangeBricksImmortal(true);
            yield return WaitForSeconds;
            ChangeBricksImmortal(false);
            Player.DeleteEffect(this);
        }

        private void ChangeBricksImmortal(bool immortalBrick)
        {
            SetActive(immortalBrick);

            foreach (Transform brick in _filtredBricks)
                brick.GetComponent<Brick>().SetBoolImmortal(immortalBrick);
        }

        private void SetList()
        {
            _bricks = new List<Transform>();
            _filtredBricks = new List<Transform>();

            FindAllChildren(_bricksContainer);

            _filtredBricks = _bricks
                .Where(p => p.gameObject.GetComponent<Brick>() && !p.gameObject.GetComponent<Brick>().IsEternal &&
                            p.gameObject.activeSelf == true).ToList();
        }

        private void FindAllChildren(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                _bricks.Add(child);
                FindAllChildren(child);
            }
        }
    }
}
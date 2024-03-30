using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bricks;
using Statistics;
using UnityEngine;

namespace ModificationFiles.BuffsFiles
{
    public class BonusTarget : Modification
    {
        [SerializeField] private Transform _bricks;
        [SerializeField] private Material _newMaterial;
        [SerializeField] private Effect[] _effects;
        [SerializeField] private BuffCounter _buffCounter;

        private List<Brick> _bricksList;
        private List<Brick> _filtredBrick;
        private int _randomIndex;
        private int _randomEffectIndex;
        private Effect _startEffect;
        private Material _startMaterial;
        private List<Renderer> _renderers;

        protected override void Awake()
        {
            base.Awake();
            _renderers = new List<Renderer>();
            FindAllChildren(_bricks);
        }

        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                StartCoroutine(OnBonusTargetActivated());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Reset();
        }

        private IEnumerator OnBonusTargetActivated()
        {
            _filtredBrick = _bricksList
                .Where(p => !p.IsEternal && p.gameObject.activeSelf == true).ToList();

            if (_filtredBrick.Count > 0)
            {
                Change();
                yield return WaitForSeconds;
                Reset();
                Player.DeleteEffect(this);
            }
        }

        private void Change()
        {
            EnableBuffUI();
            _randomIndex = GetRandomIndex(_filtredBrick.Count);
            _randomEffectIndex = GetRandomIndex(_effects.Length);
            _startMaterial = _renderers[_randomIndex].material;
            _startEffect = _filtredBrick[_randomIndex].EffectElement;

            if (_startEffect == null)
                _buffCounter.IncreaseBuffCount();

            _filtredBrick[_randomIndex].SetEffect(_effects[_randomEffectIndex]);
            _filtredBrick[_randomIndex].EnableTargetBonus();
            _renderers[_randomIndex].material = _newMaterial;
        }

        private void FindAllChildren(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                Brick brick = child.GetComponent<Brick>();
                Renderer renderer = child.GetComponent<Renderer>();

                if (brick != null && !brick.IsEternal && child.gameObject.activeSelf)
                {
                    _bricksList.Add(brick);
                    if (renderer != null)
                        _renderers.Add(renderer);
                }

                FindAllChildren(child);
            }
        }

        private int GetRandomIndex(int count)
        {
            var random = new System.Random();
            return random.Next(count);
        }

        private void Reset()
        {
            DisableBuffUI();
            _filtredBrick[_randomIndex].SetEffect(_startEffect);
            _filtredBrick[_randomIndex].DisableTargetBonus();
            _renderers[_randomIndex].material = _startMaterial;

            if (_filtredBrick[_randomIndex].gameObject.activeSelf != false && _startEffect == null)
                _buffCounter.DecreaseBuffCount();
        }
    }
}
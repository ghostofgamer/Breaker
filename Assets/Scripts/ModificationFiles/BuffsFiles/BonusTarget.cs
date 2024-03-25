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

        private List<Transform> _bricksList;
        private List<Transform> _filtredBrick;
        private int _randomIndex;
        private int _randomEffectIndex;
        private Effect _startEffect;
        private Material _startMaterial;

        public override void ApplyModification()
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
            _bricksList = new List<Transform>();
            _filtredBrick = new List<Transform>();
            FindAllChildren(_bricks);


            _filtredBrick = _bricksList
                .Where(p => p.gameObject.GetComponent<Brick>() && !p.gameObject.GetComponent<Brick>().IsEternal &&
                            p.gameObject.activeSelf == true).ToList();

            foreach (var VARIABLE in _filtredBrick)
            {
                Debug.Log(VARIABLE.name);
            }

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
            SetActive(true);
            _randomIndex = GetRandomIndex(_filtredBrick.Count);
            _randomEffectIndex = GetRandomIndex(_effects.Length);
            _startMaterial = _filtredBrick[_randomIndex].GetComponent<Renderer>().material;
            _startEffect = _filtredBrick[_randomIndex].GetComponent<Brick>().EffectElement;

            if (_startEffect == null)
                _buffCounter.IncreaseBuffCount();

            _filtredBrick[_randomIndex].GetComponent<Brick>().SetEffect(_effects[_randomEffectIndex], true);
            _filtredBrick[_randomIndex].GetComponent<Renderer>().material = _newMaterial;
        }

        private void FindAllChildren(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);
                _bricksList.Add(child);
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
            SetActive(false);
            _filtredBrick[_randomIndex].GetComponent<Brick>().SetEffect(_startEffect, false);
            _filtredBrick[_randomIndex].GetComponent<Renderer>().material = _startMaterial;

            if (_filtredBrick[_randomIndex].gameObject.activeSelf != false && _startEffect == null)
                _buffCounter.DecreaseBuffCount();
        }
    }
}
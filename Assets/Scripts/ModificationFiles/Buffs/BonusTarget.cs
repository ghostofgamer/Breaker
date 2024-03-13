using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bricks;
using Statistics;
using UnityEngine;

namespace ModificationFiles.Buffs
{
    public class BonusTarget : Modification
    {
        [SerializeField] private Transform _bricks;
        [SerializeField] private Material _newMaterial;
        [SerializeField] private Effect[] _effects;
        [SerializeField] private BuffCounter _buffCounter;

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

        private IEnumerator OnBonusTargetActivated()
        {
            List<Transform> bricksList = new List<Transform>();
            _filtredBrick = new List<Transform>();

            for (int i = 0; i < _bricks.childCount; i++)
                bricksList.Add(_bricks.GetChild(i));

            _filtredBrick = bricksList
                .Where(p => p.gameObject.GetComponent<Brick>() && !p.gameObject.GetComponent<Brick>().IsEternal &&
                            p.gameObject.activeSelf == true).ToList();

            for (int i = 0; i < _filtredBrick.Count; i++)
            {
                Debug.Log(_filtredBrick[i].name);
            }
        
            if (_filtredBrick.Count > 0)
            {
                Change();
                yield return WaitForSeconds;
                Reset();
                Player.DeleteEffect(this);
            }
        }

        public override void StopModification()
        {
            Reset();
        }

        private void Change()
        {
            SetActive(true);
            _randomIndex = GetRandomIndex(_filtredBrick.Count);
            _randomEffectIndex = GetRandomIndex(_effects.Length);
            _startMaterial = _filtredBrick[_randomIndex].GetComponent<Renderer>().material;
            _startEffect = _filtredBrick[_randomIndex].GetComponent<Brick>().EffectElement;

            if (_startEffect == null)
            {
                _buffCounter.IncreaseBuffCount();
            }

            _filtredBrick[_randomIndex].GetComponent<Brick>().SetEffect(_effects[_randomEffectIndex], true);
            _filtredBrick[_randomIndex].GetComponent<Renderer>().material = _newMaterial;
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
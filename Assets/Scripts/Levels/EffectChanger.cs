using UnityEngine;

namespace Levels
{
    public class EffectChanger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _dontSelectedCircle;
        [SerializeField] private ParticleSystem _selectedCircle;
        [SerializeField] private ParticleSystem[] _effectsSelect;
        [SerializeField] private ParticleSystem[] _lineMove;
        [SerializeField] private ParticleSystem[] _line;

        public void ColorChanger(Color color)
        {
            var module = _dontSelectedCircle.main;
            var selectCircle = _selectedCircle.main;
            module.startColor = color;
            selectCircle.startColor = color;

            for (int i = 0; i < _effectsSelect.Length; i++)
            {
                var effectColor = _effectsSelect[i].main;
                effectColor.startColor = color;
            }
        }

        public void SetLine(int index, Color color)
        {
            ParticleSystem.MainModule moduleMain = _line[index].main;
            moduleMain.startColor = color;
        }

        public void ActivationEffects()
        {
            foreach (ParticleSystem effect in _effectsSelect)
                effect.Play();
        }

        public void SelectedEffectPlay()
        {
            _selectedCircle.Play();
        }

        public void StopParticles()
        {
            SelectedEffectStop();

            for (int i = 0; i < _effectsSelect.Length; i++)
                _effectsSelect[i].Stop();
        }

        public void LineMoveActivation(int index)
        {
            _lineMove[index].Play();
        }

        private void SelectedEffectStop()
        {
            _selectedCircle.Stop();
        }
    }
}
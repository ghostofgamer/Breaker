using UnityEngine;

namespace Levels
{
    public class EffectInstaller : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _dontSelectedCircle;
        [SerializeField] private ParticleSystem _selectedCircle;
        [SerializeField] private ParticleSystem[] _effectsSelect;
        [SerializeField] private ParticleSystem[] _lineMove;

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

        public void ActivationEffects()
        {
            foreach (ParticleSystem effect in _effectsSelect)
                effect.Play();
        }

        public void SelectedEffectPlay()
        {
            _selectedCircle.Play();
        }

        public void SelectedEffectStop()
        {
            _selectedCircle.Stop();
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
    }
}
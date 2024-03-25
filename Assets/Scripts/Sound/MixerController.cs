using Enum;
using SaveAndLoad;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    public class MixerController : MonoBehaviour
    {
        [SerializeField] private string _options;
        [SerializeField] private AudioMixerGroup _outputGroup;
        [SerializeField] private TMP_Text _onSound;
        [SerializeField] private TMP_Text _offSound;
        [SerializeField] private SoundMixer _soundMixer;
        [SerializeField] private Load _load;
        [SerializeField] private Save _save;
        [SerializeField] private AudioSource _audioSource;

        private bool _isMuted;
        private float _startVolume = 0;
        private float _muteValue = -80f;

        private void Start()
        {
            LoadVolume();
            UpdateSoundInfo();
        }

        public void ReduceGroupVolume()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            float currentVolume;
            bool success = _outputGroup.audioMixer.GetFloat(_options, out currentVolume);

            if (success)
            {
                float targetVolume = _isMuted ? _startVolume : _muteValue;
                _outputGroup.audioMixer.SetFloat(_options, targetVolume);
                _isMuted = !_isMuted;
            }
            else
            {
                return;
            }

            UpdateSoundInfo();
            SaveVolume();
        }

        private void UpdateSoundInfo()
        {
            _onSound.enabled = !_isMuted;
            _offSound.enabled = _isMuted;
        }

        private void SaveVolume()
        {
            float volume;
            _outputGroup.audioMixer.GetFloat(_options, out volume);
            _save.SetData(_soundMixer.ToString(), volume);
        }

        private void LoadVolume()
        {
            float volume = _load.Get(_soundMixer.ToString(), _startVolume);
            _outputGroup.audioMixer.SetFloat(_options, volume);
            _isMuted = volume == _muteValue;
        }
    }
}
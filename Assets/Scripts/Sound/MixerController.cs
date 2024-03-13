using Enum;
using SaveAndLoad;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    public class MixerController : MonoBehaviour
    {
        [SerializeField]private string _options;
        [SerializeField]private AudioMixerGroup _outputGroup;
        [SerializeField] private TMP_Text _onSound;
        [SerializeField] private TMP_Text _offSound;
        [SerializeField] private SoundMixer _soundMixer;
        [SerializeField] private Load _load;
        [SerializeField] private Save  _save;

        private bool _isMuted;
        private float _startVolume=0;

        private void Start()
        {
            LoadVolume();
            UpdateSoundInfo();
        }

        public void ReduceGroupVolume()
        {
            float currentVolume;
            bool success = _outputGroup.audioMixer.GetFloat(_options, out currentVolume);
            /*_onSound.enabled = !_onSound.enabled;
        _offSound.enabled = _offSound.enabled ? false : true;*/
        
        
            if (success)
            {
                float targetVolume = _isMuted ? 0f : -80f;
                _outputGroup.audioMixer.SetFloat(_options, targetVolume);
                _isMuted = !_isMuted;
            }
            else
            {
                Debug.Log("Failed to get volume parameter from mixer group: ");
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
            _save.SetData(_soundMixer.ToString(),volume);
            Debug.Log(volume);
        }

        private void LoadVolume()
        {
            float volume = _load.Get(_soundMixer.ToString(), _startVolume);
            _outputGroup.audioMixer.SetFloat(_options, volume);
            _isMuted = volume == -80f;
        }
    }
}

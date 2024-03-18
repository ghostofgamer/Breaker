using Bonus;
using ModificationFiles;
using ModificationFiles.EffectApplier;
using Statistics;
using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    public class PlatformaTrigger : MonoBehaviour
    {
        [SerializeField] private BuffApplier _buffApplier;
        [SerializeField] private DebuffApplier _debuffApplier;
        [SerializeField] private NeutralApplier _neutralApplier;
        [SerializeField] private BonusCounter _bonusCounter;
        [SerializeField] private BuffCounter _buffCounter;
        [SerializeField] private FragmentsCounter _fragmentsCounter;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClipBonusCatch;
        [SerializeField] private AudioClip _audioClipModificationCatch;
        [SerializeField] private ResistanceDebuff _resistanceDebuff;
        [SerializeField] private ChanceBonus _chanceBonus;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Buff buff))
            {
                _buffCounter.CollectBuff();
                CatchEffect(_buffApplier, buff);
            }

            if (other.TryGetComponent(out Debuff debuff))
            {
                if (_resistanceDebuff != null)
                {
                    if (_resistanceDebuff.TryResiste() && _resistanceDebuff.enabled)
                    {
                        Debug.Log("Сопротивление");
                        debuff.Destroy();
                        return;
                    }

                    Debug.Log("применение");
                    CatchEffect(_debuffApplier, debuff);
                }
            }


            if (other.TryGetComponent(out Neutral neutral))
                CatchEffect(_neutralApplier, neutral);

            if (other.TryGetComponent(out BonusDeath bonusDeath))
            {
                _audioSource.PlayOneShot(_audioClipBonusCatch);
                _fragmentsCounter.FragmentsCollect();

                if (_chanceBonus.enabled)
                {
                    bonusDeath.SetValue(_chanceBonus.TryIncreaseBonus(bonusDeath.Reward));
                }

                _bonusCounter.AddBonus(bonusDeath.Reward);
                bonusDeath.Die();
            }
        }

        public void Init(BuffApplier buffApplier, DebuffApplier debuffApplier, NeutralApplier neutralApplier)
        {
            _buffApplier = buffApplier;
            _debuffApplier = debuffApplier;
            _neutralApplier = neutralApplier;
        }

        private void CatchEffect(EffectApplier effectApplier, Effect effect)
        {
            _audioSource.PlayOneShot(_audioClipModificationCatch);
            effectApplier.Apply(effect.BuffType);
            effect.Destroy();
        }
    }
}
using PlayerFiles.PlatformaContent;
using SaveAndLoad;
using UnityEngine;

namespace Skins
{
    public class SkinPlatformLoader : MonoBehaviour
    {
        private const int StrongerExplosion = 1;
        private const int ResistDebuff = 2;
        private const int ChanceShield = 3;
        private const int LuckySave = 4;
        private const int ElectricDischarge = 5;
        private const int IncreaseDrop = 6;

        [SerializeField] private Load _load;
        [SerializeField] private GameObject[] _skins;
        [SerializeField] private MagnifierRadiusExplosion _magnifierRadiusExplosion;
        [SerializeField] private ResistanceDebuff _resistanceDebuff;
        [SerializeField] private ChanceShield _chanceShield;
        [SerializeField] private LuckySave _luckySave;
        [SerializeField] private ElectricBallActivator _electricBallActivator;
        [SerializeField] private ChanceBonus _chanceBonus;
        [SerializeField] private bool _isOriginal;

        private int _startIndex = 0;

        private void Start()
        {
            int index = _load.Get(Save.ActiveCapsuleIndex, _startIndex);

            _skins[index].SetActive(true);

            if (_isOriginal)
                ModificationActivation(index);
        }

        private void ModificationActivation(int index)
        {
            switch (index)
            {
                case StrongerExplosion:
                    Debug.Log("1");
                    _magnifierRadiusExplosion.enabled = true;
                    break;

                case ResistDebuff:
                    Debug.Log("2");
                    _resistanceDebuff.enabled = true;
                    break;

                case ChanceShield:
                    Debug.Log("3");
                    _chanceShield.enabled = true;
                    break;

                case LuckySave:
                    Debug.Log("4");
                    _luckySave.enabled = true;
                    break;

                case ElectricDischarge:
                    Debug.Log("5");
                    _electricBallActivator.enabled = true;
                    break;

                case IncreaseDrop:
                    Debug.Log("6");
                    _chanceBonus.enabled = true;
                    break;

                default:
                    break;
            }
        }
    }
}
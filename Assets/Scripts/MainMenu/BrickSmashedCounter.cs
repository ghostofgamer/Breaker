using SaveAndLoad;
using TMPro;
using UnityEngine;

namespace MainMenu
{
    public class BrickSmashedCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _amountText;
        [SerializeField] private Load _load;
        [SerializeField] private Save _save;

        private int _brickSmashedCount;
        private int _startAmount = 0;

        private void Start()
        {
            _brickSmashedCount = _load.Get(Save.BrickSmashed, _startAmount);

            if (_amountText != null)
                ShowInfo();
        }

        public void AddValue(int value)
        {
            _brickSmashedCount += value;
            _save.SetData(Save.BrickSmashed, _brickSmashedCount);
        }

        private void ShowInfo()
        {
            _amountText.text = _brickSmashedCount.ToString();
        }
    }
}
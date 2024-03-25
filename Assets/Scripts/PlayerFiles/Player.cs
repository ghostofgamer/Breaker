using System.Collections.Generic;
using ModificationFiles;
using UnityEngine;

namespace PlayerFiles
{
    public class Player : MonoBehaviour
    {
        private List<Modification> _modifications = new List<Modification>();

        public List<Modification> Modifications => _modifications;

        public void ClearList()
        {
            _modifications.Clear();
        }

        public bool TryApplyEffect(Modification modification)
        {
            if (!_modifications.Contains(modification))
            {
                _modifications.Add(modification);
                return true;
            }

            return false;
        }

        public void DeleteEffect(Modification modification)
        {
            if (_modifications.Contains(modification))
                _modifications.Remove(modification);
        }
    }
}
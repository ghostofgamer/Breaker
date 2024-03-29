using UnityEngine;
using Random = UnityEngine.Random;

namespace ModificationFiles.NeutralFiles
{
    public class RandomEffect : Modification
    {
        [SerializeField] private Modification[] _modifications;

        private int _index;

        public override void OnApplyModification()
        {
            _index = Random.Range(0, _modifications.Length);
            _modifications[_index].OnApplyModification();
        }

        public override void StopModification()
        {
        }
    }
}
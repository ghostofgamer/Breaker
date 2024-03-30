using Random = UnityEngine.Random;

namespace PlayerFiles.ModificationContent
{
    public class ResistanceDebuff : BaseModification
    {
        public bool TryResiste()
        {
            return Random.Range(MinValue, MaxValue) > BonusChances;
        }
    }
}
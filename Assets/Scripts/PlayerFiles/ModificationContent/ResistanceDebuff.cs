using Random = UnityEngine.Random;

namespace PlayerFiles.ModificationContent
{
    public class ResistanceDebuff : PlatformModification
    {
        public bool TryResiste()
        {
            return Random.Range(MinValue, MaxValue) > BonusChances;
        }
    }
}
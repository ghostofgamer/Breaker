using Random = UnityEngine.Random;

namespace PlayerFiles.ModificationContent
{
    public class ResistanceDebuff : PlatformModification
    {
        public bool TryResiste()
        {
            RandomValue = Random.Range(MinValue, MaxValue);
            return RandomValue > BonusChances;
        }
    }
}
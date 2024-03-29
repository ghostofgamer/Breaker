using Random = UnityEngine.Random;

namespace PlayerFiles.ModificationContent
{
    public class ChanceBonus : PlatformModification
    {
        private int _factor = 2;

        public int GetBonus(int reward)
        {
            if (TryIncreaseBonus(ref reward))
                return reward;

            return reward;
        }

        private bool TryIncreaseBonus(ref int reward)
        {
            if (Random.Range(MinValue, MaxValue) > BonusChances)
                return false;

            reward *= _factor;
            return true;
        }
    }
}
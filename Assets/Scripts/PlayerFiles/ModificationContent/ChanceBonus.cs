using Random = UnityEngine.Random;

namespace PlayerFiles.ModificationContent
{
    public class ChanceBonus : PlatformModification
    {
        private int _factor = 2;

        public int TryIncreaseBonus(int reward)
        {
            RandomValue = Random.Range(MinValue, MaxValue);

            if (RandomValue > BonusChances)
                return reward;

            reward *= _factor;
            return reward;
        }
    }
}
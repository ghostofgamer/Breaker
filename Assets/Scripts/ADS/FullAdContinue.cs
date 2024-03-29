namespace ADS
{
    public class FullAdContinue : FullAdOverScene
    {
        private const string ChooseLvlScene = "ChooseLvlScene";

        protected override string GetScenenameToLoad()
        {
            return ChooseLvlScene;
        }
    }
}
namespace ADS
{
    public class FullAdExit : FullAdOverScene
    {
        private const string MainScene = "MainScene";

        protected override string GetScenenameToLoad()
        {
            return MainScene;
        }
    }
}
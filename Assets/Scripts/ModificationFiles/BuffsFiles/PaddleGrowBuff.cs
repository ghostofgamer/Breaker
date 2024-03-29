namespace ModificationFiles.BuffsFiles
{
    public class PaddleGrowBuff : PaddleChanger
    {
        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                Coroutine = StartCoroutine(Resize());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Reset();
        }
    }
}
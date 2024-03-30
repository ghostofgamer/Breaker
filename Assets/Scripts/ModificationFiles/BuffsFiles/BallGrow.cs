namespace ModificationFiles.BuffsFiles
{
    public class BallGrow : BallSizeChanger
    {
        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                StartCoroutine(Resize());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Reset();
        }
    }
}
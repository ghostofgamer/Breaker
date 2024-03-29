namespace ModificationFiles.DebuffsFiles
{
    public class BallShrink : BallSizeChanger
    {
        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                StartCoroutine(Resize(BallMover));
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Reset();
        }
    }
}
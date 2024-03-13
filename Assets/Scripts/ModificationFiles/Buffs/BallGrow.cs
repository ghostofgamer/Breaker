namespace ModificationFiles.Buffs
{
    public class BallGrow : BallSizeChanger
    {
        public override void ApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                StartCoroutine(OnBallChangeSize(BallMover));
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Reset();
        }
    }
}
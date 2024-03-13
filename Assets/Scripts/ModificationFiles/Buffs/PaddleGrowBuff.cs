namespace ModificationFiles.Buffs
{
    public class PaddleGrowBuff : PaddleChanger
    {
        public override void ApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if(Coroutine!=null)
                    StopCoroutine(Coroutine);
            
                Coroutine = StartCoroutine(OnPaddleSizeChanger());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Reset();
        }
    }
}

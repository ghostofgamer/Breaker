using System.Collections;

namespace ModificationFiles.DebuffsFiles
{
    public class Reverse : Modification
    {
        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                StartCoroutine(OnReversePaddleActivated());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Stop();
        }

        private void Stop()
        {
            SetActive(false);
            BaseMovement.DisableReverse();
        }

        private IEnumerator OnReversePaddleActivated()
        {
            SetActive(true);
            BaseMovement.EnableReverse();
            yield return WaitForSeconds;
            Stop();
            Player.DeleteEffect(this);
        }
    }
}
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
            PlatformaMover.SetReverse(false);
        }

        private IEnumerator OnReversePaddleActivated()
        {
            SetActive(true);
            PlatformaMover.SetReverse(true);
            yield return WaitForSeconds;
            Stop();
            Player.DeleteEffect(this);
        }
    }
}
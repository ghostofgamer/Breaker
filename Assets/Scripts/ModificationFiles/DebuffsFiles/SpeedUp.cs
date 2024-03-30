using System.Collections;

namespace ModificationFiles.DebuffsFiles
{
    public class SpeedUp : Modification
    {

        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                StartCoroutine(OnSpeedUpActivated());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Stop();
        }

        private void Stop()
        {
            DisableBuffUI();
            BallMover.DisableSpeedUpEffect();
        }

        private IEnumerator OnSpeedUpActivated()
        {
            EnableBuffUI();
            BallMover.EnableSpeedUpEffect();
            yield return WaitForSeconds;
            Stop();
            Player.DeleteEffect(this);
        }
    }
}
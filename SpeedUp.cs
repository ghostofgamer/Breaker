using System.Collections;
using ModificationFiles;

public class SpeedUp : Modification
{
    private float _startSpeed;

    public override void ApplyModification()
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
        SetActive(false);
        BallMover.SetValue(_startSpeed,false);
    }

    private IEnumerator OnSpeedUpActivated()
    {
        SetActive(true);
        _startSpeed = BallMover.MinSpeed;
        BallMover.SetValue(_startSpeed * 2,true);
        yield return WaitForSeconds;
        Stop();
        Player.DeleteEffect(this);
    }
}
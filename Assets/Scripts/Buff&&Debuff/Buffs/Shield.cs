using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Modification
{
    [SerializeField] private GameObject _shield;
    // [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    public override void ApplyModification(Player player)
    {
        if (player.TryApplyEffect(this))
            StartCoroutine(OnShieldActivated());
    }

    public override void StopModification(Player player)
    {
        
    }

    /*public void ShieldActivated(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnShieldActivated(platformaMover));
    }*/

    private IEnumerator OnShieldActivated()
    {
        _shield.SetActive(true);
        yield return _waitForSeconds;
        Stop();
        /*_shield.SetActive(false);
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);*/
    }

    private void Stop()
    {
        _shield.SetActive(false);
        Player.DeleteEffect(this);
    }
}

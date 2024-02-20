using System.Collections;
using UnityEngine;

public class Portal : Modification
{
    [SerializeField] private GameObject _portal;
    [SerializeField] private GameObject[] _walls;

    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            Coroutine = StartCoroutine(OnPortalActivated());
        }
    }

    public override void StopModification()
    {
        SetValue(false);
    }

    private IEnumerator OnPortalActivated()
    {
        SetValue(true);
        yield return WaitForSeconds;
        SetValue(false);
        Player.DeleteEffect(this);
    }

    private void SetValue(bool value)
    {
        foreach (var wall in _walls)
            wall.GetComponent<BoxCollider>().enabled = !value;

        BallPortalMover.SetValue(value);
        _portal.SetActive(value);
    }
}
using System.Collections;
using UI.Buttons;
using UnityEngine;


public class BackButton : AbstractButton
{
    [SerializeField] private MainScreen _mainScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private GameObject _settingsButton;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);

    protected override void OnClick()
    {
        StartCoroutine(ChangeOpenMenu());
    }

    private IEnumerator ChangeOpenMenu()
    {
        _settingsScreen.GetComponent<FadeObject>().FadeOn();
        yield return _waitForSeconds;
        _settingsButton.SetActive(true);
        gameObject.SetActive(false);
        _mainScreen.GetComponent<FadeObject>().FadeOut();
    }
}
using System.Collections;
using System.Collections.Generic;
using ADS;
using TMPro;
using UI.Screens;
using UI.Screens.EndScreens;
using UnityEngine;

public class ClaimRewardButton : AbstractButton
{
    [SerializeField] private GameObject[] _gameObjects;
    [SerializeField] private TMP_Text _creditsTxt;
    [SerializeField] private LevelComplite _levelComplite;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private RewardTripleCredit _rewardTripleCredit;
    // [SerializeField] private TMP_Text _claimTripleCreditTxt;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
    private int _credits = 0;

    public int Credits => _credits;
    
    protected override void OnClick()
    {
        Button.interactable = false;
        _rewardTripleCredit.Show();
        
        /*_levelComplite.gameObject.SetActive(false);
        _victoryScreen.OpenScreen(_credits);*/
    }

    public void SetActive(int credits)
    {
        gameObject.SetActive(true);
        _credits = credits * 3;
        StartCoroutine(OpenButton(credits));
    }
    
    private IEnumerator OpenButton(int credits)
    {
        yield return _waitForSeconds;
        _creditsTxt.text = _credits.ToString();
        
        foreach (GameObject gameObject in _gameObjects)
            gameObject.SetActive(true);
    }
}
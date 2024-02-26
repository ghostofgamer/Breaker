using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClaimButton : AbstractButton
{
    [SerializeField] private LevelComplite _levelComplite;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private TMP_Text _creditsTxt;

    private float _credits = 0 ;
    
    protected override void OnClick()
    {
        _levelComplite.gameObject.SetActive(false);
        _victoryScreen.Open();
    }

    public void SetValue(int credits)
    {
        // _credits = credits;
        while (_credits < credits)
        {
            _credits = Mathf.MoveTowards(_credits, credits, 5 * Time.deltaTime);
             _creditsTxt.text = _credits.ToString();
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using PlayerFiles.PlatformaContent;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _numbersText;
    [SerializeField] private PlatformaMover _platformaMover;

    private WaitForSecondsRealtime _waitForSeconds = new WaitForSecondsRealtime(1f);
    
    public void GoResume()
    {
        StartCoroutine(Resume());
    }

    private IEnumerator Resume()
    {
        foreach (TMP_Text txt in _numbersText)
        {
            txt.gameObject.SetActive(true);
            txt.GetComponent<Animator>().Play("Play");
            yield return _waitForSeconds;
            txt.gameObject.SetActive(false);
        }
        
        _platformaMover.enabled = true;
        Time.timeScale = 1;
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _numbersText;
    [SerializeField] private PlatformaMover _platformaMover;
    [SerializeField] private BallMover _ballMover;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    
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
        _ballMover.enabled = true;
        _ballMover.GetComponent<Rigidbody>().isKinematic = true;
        // Time.timeScale = 1;
    }
}
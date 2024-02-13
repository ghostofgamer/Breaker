using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SelectLevelButton : AbstractButton
{
    [SerializeField] private int _sceneNumber;

    protected override void OnClick()
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
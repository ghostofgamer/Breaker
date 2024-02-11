using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

public class GameReady : MonoBehaviour
{
    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
YandexGamesSdk.GameReady();
#endif
    }
}
using Agava.YandexGames;
using UnityEngine;

namespace ADS
{
    public class FullAds : Ad
    {
        public override void Show()
        {
            if (YandexGamesSdk.IsInitialized)
                InterstitialAd.Show(OnOpen, OnClose);
        }
    }
}

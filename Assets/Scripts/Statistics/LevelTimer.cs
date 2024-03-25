using System;
using System.Diagnostics;
using UnityEngine;

namespace Statistics
{
    public class LevelTimer : MonoBehaviour
    {
        private Stopwatch _stopWatch;
        private float _startTime;
        private string _timeString;
        private bool _levelComplite = false;

        private void Start()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        private void Update()
        {
            if (_levelComplite)
                return;

            float elapsedTime = Time.time - _startTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
            _timeString = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }

        public string GetTime()
        {
            _levelComplite = true;
            return _timeString;
        }
    }
}
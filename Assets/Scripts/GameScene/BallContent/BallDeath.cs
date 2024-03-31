using System;
using UnityEngine;

namespace GameScene.BallContent
{
    public class BallDeath : MonoBehaviour
    {
        [SerializeField]private BallMover _ballMover;
        
        public event Action Dying;
        
        public void Die()
        {
            Dying?.Invoke();
            gameObject.SetActive(false);
            _ballMover.OnStopMove();
            Time.timeScale = 1;
        }
    }
}

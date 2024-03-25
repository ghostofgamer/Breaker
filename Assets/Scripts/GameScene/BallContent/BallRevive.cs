using UnityEngine;

namespace GameScene.BallContent
{
    public class BallRevive : MonoBehaviour
    {
        public void Revive()
        {
            gameObject.SetActive(true);
        }
    }
}
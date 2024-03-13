using UnityEngine;

namespace GameScene.BallContent
{
    public class BallRevive : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
    
        public void Revive()
        {
            gameObject.SetActive(true);
        }
    }
}

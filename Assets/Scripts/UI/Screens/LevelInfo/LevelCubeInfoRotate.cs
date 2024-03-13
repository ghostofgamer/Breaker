using UnityEngine;

namespace UI.Screens.LevelInfo
{
    public class LevelCubeInfoRotate : MonoBehaviour
    {
    
        /*
    public float speed = 10.0f;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Движение вдоль оси X в пространстве экрана
        Vector2 position = rectTransform.anchoredPosition;
        position.x += speed * Time.deltaTime;
        rectTransform.anchoredPosition = position;
    }*/
        [SerializeField] private float _speed;
    
        private void Update()
        {
            transform.Rotate(Vector3.right*_speed*Time.deltaTime);
        }
    }
}

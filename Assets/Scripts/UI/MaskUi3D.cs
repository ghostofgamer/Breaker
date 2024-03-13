using UnityEngine;

namespace UI
{
    public class MaskUi3D : MonoBehaviour
    {
        public GameObject maskObject; // 3D объект, который будет использоваться в качестве маски
        public RectTransform canvasRectTransform; // RectTransform UI Canvas
        public RectTransform maskRectTransform; // RectTransform UI объекта, который будет использоваться в качестве маски

        private Camera mainCamera;

        void Start()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            // Проектируем позицию 3D объекта на экран
            Vector2 screenPoint = mainCamera.WorldToScreenPoint(maskObject.transform.position);

            // Переводим экранные координаты в координаты RectTransform Canvas
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPoint, null, out Vector2 localPoint);

            // Обновляем позицию маски
            maskRectTransform.anchoredPosition = localPoint;
        }
    }
}

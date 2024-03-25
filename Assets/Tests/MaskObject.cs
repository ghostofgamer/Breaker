using UnityEngine;

namespace Tests
{
    public class MaskObject : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<MeshRenderer>().material.renderQueue = 3002;
        }
    }
}
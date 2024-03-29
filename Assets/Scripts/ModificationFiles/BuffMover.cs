using GameScene;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace ModificationFiles
{
    public class BuffMover : Mover
    {
        protected override void Update()
        {
            transform.Translate((-Vector3.forward * Speed) * Time.deltaTime);
            base.Update();
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Knob : MonoBehaviour
    {
        [SerializeField] private SwipeLayout _swipeLayout;

        public void OnKnobClicked(Button button)
        {
            _swipeLayout.OnKnobClicked(button);
        }
    }
}
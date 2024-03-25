using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public class RestartButton : AbstractButton
    {
        protected override void OnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

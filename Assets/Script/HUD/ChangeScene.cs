using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void loadSceneFase1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void loadSceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadSceneCreditos()
    {
        SceneManager.LoadScene("Credits");
    }
}

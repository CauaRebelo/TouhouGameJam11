using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void loadSceneFase1()
    {
        SceneManager.LoadScene("0a4");
    }

    public void loadSceneMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadSceneCreditos()
    {
        SceneManager.LoadScene("Statistics");
    }
}

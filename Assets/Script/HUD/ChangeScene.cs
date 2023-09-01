using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void loadSceneFase1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void loadSceneFase2()
    {
        SceneManager.LoadScene("Level2");
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

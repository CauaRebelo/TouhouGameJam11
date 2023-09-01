using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void loadSceneFase1()
    {
        SceneManager.LoadScene("SampleScene");
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

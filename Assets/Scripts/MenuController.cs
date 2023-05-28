using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        LoadSceneManager.instance.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

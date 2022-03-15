using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void loadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void loadResult()
    {
        SceneManager.LoadScene("Result");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

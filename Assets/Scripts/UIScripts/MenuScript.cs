using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void doExitGame()
    {
        Application.Quit();
    }

    public void doStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void doCredits()
    {
        SceneManager.LoadScene(3);
    }

    public void doTitle()
    {
        SceneManager.LoadScene(0);
    }


    public void doWorld2()
    {
        SceneManager.LoadScene(2);
    }
    public void doWorld3()
    {
        SceneManager.LoadScene(5);
    }

    public void doLevelSelect()
    {
        SceneManager.LoadScene(4);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    void Awake()
    {
        GameManager.Instance.state = States.MainMenu;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Tutorial");
        GameManager.Instance.state = States.Tutorial;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Scene : StartMenu ,Role, GameOverMenu
/// </summary>
public class Menu : MonoBehaviour
{

    private Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        if (button.tag == "StartButton")
        {
            button.onClick.AddListener(Menustart);
        }
        else if (button.tag == "RestartButton")
        {
            button.onClick.AddListener(RestartGame);
        }
        else if (button.tag == "ExitButton")
        {
            button.onClick.AddListener(QuitGame);
        }
    }
    // Update is called once per frame
    public void Menustart()
    {
        SceneManager.LoadScene("ChooseRole");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Fight");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
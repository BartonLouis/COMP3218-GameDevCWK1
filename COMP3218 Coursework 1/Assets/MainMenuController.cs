using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelSelectMenu;

    public void Start() {
        MainMenu.SetActive(true);
        LevelSelectMenu.SetActive(false);
    }

    public void Tutorial() {
        SceneManager.LoadScene("Tutorial");
    }

    public void LevelSelect() {
        MainMenu.SetActive(false);
        LevelSelectMenu.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }

    public void Back() {
        MainMenu.SetActive(true);
        LevelSelectMenu.SetActive(false);
    }

    public void Level1() {
        SceneManager.LoadScene("Level1");
    }

    public void Level2() {
        SceneManager.LoadScene("Level2");
    }

    public void Level3() {
        SceneManager.LoadScene("Level3");
    }
}

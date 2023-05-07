using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject button;
    public void Start()
    {
        
    }
    public void PlayGame()
    {

        PlayerPrefs.SetFloat("DifficultyStat",button.GetComponent<DifficultyManagement>().difficultyLevel);
        SceneManager.LoadScene(8);// this can load the scene number 1 (game)//SceneManager.GetActiveScene().buildIndex +1


    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);//replays the level without re-setting the difficulty
    }

    public void RestartGame() //restarts and re-sets the difficulty
    {

        PlayerPrefs.SetFloat("DifficultyStat", 1);
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {

        Application.Quit();
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene(1);
    }
}
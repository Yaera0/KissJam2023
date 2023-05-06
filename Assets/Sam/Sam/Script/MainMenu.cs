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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// this can load the scene number 1 (game)//SceneManager.GetActiveScene().buildIndex +1


    }
    public void QuitGame()
    {

        Application.Quit();
    }

    public void PlayCredits()
    {
        SceneManager.LoadScene(2);
    }
}
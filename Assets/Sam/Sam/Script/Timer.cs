using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{
    public float TimeLeft = 60;
    public TMP_Text TimerText;
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        string TimeString = TimeLeft.ToString();
        TimeString = string.Format("{0:00}", TimeLeft);
        TimerText.SetText(""+ TimeString);
        if (TimeLeft < 0.1)
        {
            if (GameObject.FindGameObjectWithTag("Finish")) 
             {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
             }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
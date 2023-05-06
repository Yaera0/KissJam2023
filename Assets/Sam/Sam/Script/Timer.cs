using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{
    bool decompteOn;

    private void Start()
    {
        decompteOn = true;
    }

    public void decompteOff()
    {
        decompteOn = false;
    }

    public float TimeLeft = 60;
    public TMP_Text TimerText;
    void Update()
    {
        try
        {
            Debug.Log(GameObject.FindGameObjectWithTag("Finish").name);
        }
        catch { }
        
        Debug.Log(GameObject.FindGameObjectWithTag("Finish") == null);
        if(decompteOn)
        {
            TimeLeft -= Time.deltaTime;
        }
        string TimeString = TimeLeft.ToString();
        TimeString = string.Format("{0:00}", TimeLeft);
        TimerText.SetText(""+ TimeString);
        if (TimeLeft < 0.1)
        {
            if (GameObject.FindGameObjectWithTag("Finish")==null) 
             {
                SceneManager.LoadScene(3);
             }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
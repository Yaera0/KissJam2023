using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Timer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip rumble;
    bool once;

    public bool decompteOn;

    private void Start()
    {
        decompteOn = true;
        once=false;
        audioSource= GetComponent<AudioSource>();
    }

    public float TimeLeft = 60;
    public TMP_Text TimerText;
    void Update()
    {

        if(decompteOn)
        {
            TimeLeft -= Time.deltaTime;
        }
        if (TimeLeft < 30 && !once)
        {
            once = true;
            audioSource.PlayOneShot(rumble);
            audioSource.volume = 0;
        }
        else if(TimeLeft < 30 && once)
        {
            audioSource.volume += Time.deltaTime/15;
        }


        
        string TimeString = TimeLeft.ToString();
        TimeString = string.Format("{0:00}", TimeLeft);
        TimerText.SetText($"Temps restant avant papi orange: {TimeString}");
        if (TimeLeft < 0.1)
        {
            if (GameObject.FindGameObjectWithTag("Finish")==null) 
             {
                SceneManager.LoadScene(4);
             }
            else
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
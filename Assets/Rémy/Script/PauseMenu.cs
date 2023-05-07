using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool pause;
    [SerializeField] GameObject canvasPause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("joystick button 7"))
        {
            if (!pause)
            {
                pause = true;
                Time.timeScale = 0.0f;
                canvasPause.SetActive(true);

            }
            else
            {
                pause = false;
                Time.timeScale = 1.0f;
                canvasPause.SetActive(false);
            }
        }
            
            
        
    }
}

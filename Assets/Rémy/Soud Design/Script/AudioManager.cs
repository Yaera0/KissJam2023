using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip songMenu;
    [SerializeField] List<AudioClip> gameSong;
    [SerializeField] AudioClip songGameOver,songGoodEnding,songBadEnding;
    [SerializeField] AudioClip clementimeApp,mandarineGameOver;

    GameObject player;
    public bool scGameOver;
    bool gameOverStarted;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        gameOverStarted= false;
        audioSource= GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0) audioSource.PlayOneShot(songMenu);
        else if (index == 1) audioSource.PlayOneShot(gameSong[Mathf.RoundToInt(Random.Range(0, gameSong.Count))]);
        else if (index == 2) audioSource.PlayOneShot(songGoodEnding);
        else if (index == 3) audioSource.PlayOneShot(songBadEnding);
    }

    public void clemmApp()
    {
        audioSource.PlayOneShot(clementimeApp);
    }

    public void MandGameOver() 
    {
        audioSource.PlayOneShot(mandarineGameOver);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (scGameOver)
            {
                if (!gameOverStarted)
                {
                    gameOverStarted = true;
                    audioSource.Stop();
                    audioSource.PlayOneShot(mandarineGameOver);
                    //audioSource.PlayDelayed(0.7f);
                }
            }
            else
            {
                if (player.GetComponent<PlayerController>().vie <= 0)
                {
                    scGameOver = true;
                }
            }
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(songGameOver);
            }
        }
        
    }
}

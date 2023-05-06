using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip songMenu;
    [SerializeField] List<AudioClip> gameSong;
    [SerializeField] AudioClip songGameOver,songGoodEnding,songBadEnding;
    GameObject player;
    public bool scGameOver;
    bool gameOverStarted;
    AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        gameOverStarted= false;
        AudioSource= GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0) AudioSource.PlayOneShot(songMenu);
        else if (index == 1) AudioSource.PlayOneShot(gameSong[Mathf.RoundToInt(Random.Range(0, gameSong.Count))]);
        else if (index == 2) AudioSource.PlayOneShot(songGoodEnding);
        else if (index == 3) AudioSource.PlayOneShot(songBadEnding);
    }

    // Update is called once per frame
    void Update()
    {

        if(scGameOver)
        {
            if(!gameOverStarted)
            {
                gameOverStarted= true;
                AudioSource.Stop();
                AudioSource.PlayOneShot(songGameOver);
            }
        }
        else
        {
            if(player.GetComponent<PlayerController>().vie <= 0)
            {
                scGameOver= true;
            }
        }
    }
}

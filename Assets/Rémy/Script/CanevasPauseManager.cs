using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanevasPauseManager : MonoBehaviour
{
    [SerializeField] GameObject buttonClavier;
    [SerializeField] GameObject textClavier;
    [SerializeField] GameObject player;
    [SerializeField] GameObject MenuPause;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChangeInput()
    {
        if (player.GetComponent<PlayerController>().clavier)
        {
            player.GetComponent<PlayerController>().clavier = false;
        }
        else
        {
            player.GetComponent<PlayerController>().clavier = true;
        }

        if (player.GetComponent<PlayerController>().controller == 1)
        {
            PlayerPrefs.SetFloat("controller", 1);
        }
        else
        {
            PlayerPrefs.SetFloat("controller", 2);
        }

    }

    public void Unpause()
    {
        MenuPause.GetComponent<PauseMenu>().unPause();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().clavier) 
        {
            textClavier.GetComponent<TMP_Text>().text = "Current: Clavier";
        }
        else
        {
            textClavier.GetComponent<TMP_Text>().text = "Current: Manette";
        }
    }
}

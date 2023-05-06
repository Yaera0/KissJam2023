using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoarManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] List<AudioClip> roarPtero;
    [SerializeField] List<AudioClip> roarTripy;
    [SerializeField] List<AudioClip> roarTrex;
    bool canPlay,coroutine;
    string[] dino = { "Ptero", "Trex", "Tripy" };

    void Roar(string dino)
    {
        if (dino == "Ptero")
        {
            audioSource.PlayOneShot(roarPtero[Mathf.RoundToInt(Random.Range(0, roarPtero.Count))]);
        }
        else if (dino == "Trex")
        {
            audioSource.PlayOneShot(roarTrex[Mathf.RoundToInt(Random.Range(0, roarTrex.Count))]);
        }
        else if (dino == "Tripy")
        {
            audioSource.PlayOneShot(roarTripy[Mathf.RoundToInt(Random.Range(0, roarTripy.Count))]);
        }
        canPlay= false;
        StartCoroutine("delay1");
    }
    IEnumerator delay1()
    {
        yield return new WaitForSeconds(Random.Range(4, 8));
        canPlay= true;

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        canPlay= false;
        StartCoroutine("delay1");
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            int random = Random.Range(0, dino.Length);
            Roar(dino[random]);
            Debug.Log($"dino :{random}");
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClemMan : MonoBehaviour
{
    [SerializeField] List<GameObject> Queue;

    [SerializeField] List<GameObject> ClementinePos = new List<GameObject>();
    [SerializeField] GameObject clementineQuarterPrefab,Clementine;
    GameObject buffer;
    GameObject player;

    //param
    int nombreDeQuartiers=7;

    //param
    public bool canAppear = true;


    // Start is called before the first frame update
    void Start()
    {
        canAppear= true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            foreach (GameObject go in Queue)
            {
                if (go == null) DestroyQueue();
            }
        }
        catch
        {
            DestroyQueue();
        }


        if (player.GetComponent<PlayerController>().vie < 2)
        {
            canAppear= true;
        }
        else
        {
            canAppear= false;
        }
        if(Queue.Count== nombreDeQuartiers)
        {
            canAppear= false;
            foreach (GameObject GO in GameObject.FindGameObjectsWithTag("Quartier"))
            {
                GO.GetComponent<ClementineComponent>().disparition();
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().vie=2;
            Instantiate(Clementine, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().clemmApp();

        }

        if (canAppear)
        {
            if (GameObject.FindGameObjectsWithTag("Quartier").Length < nombreDeQuartiers)
            {
                spawnClementineQuarter(1);
            }
        }

    }

    void spawnClementineQuarter(int numberQuarter)
    {
            ClementinePos[0].transform.position = new Vector3(UnityEngine.Random.Range(-7.75f, 3.75f), UnityEngine.Random.Range(-3.75f, 3.75f), 0);
            clementineQuarterPrefab.transform.position = ClementinePos[0].transform.position + UnityEngine.Random.Range(25, 15) * Vector3.up;
            clementineQuarterPrefab.GetComponent<ClementineComponent>().spawnPoint = ClementinePos[0].transform.position;
            buffer = clementineQuarterPrefab;
            Instantiate(buffer);
        
    }

    public GameObject assign(GameObject gameOb)
    {

        Queue.Add(gameOb); 
        if (Queue.Count > 1)
        {
            return Queue[Queue.Count - 2];
        }
        else
        {
            return this.gameObject;
        }
        
    }

    public void DestroyQueue()
    {
        if(Queue.Count > 0)
        {
            foreach (GameObject gameOb in Queue)
            {
                try
                {
                    gameOb.GetComponent<ClementineComponent>().inc = -2;
                }
                catch
                {
                    Queue.Clear();
                }

            }
        }


        Queue.Clear();
    }
}

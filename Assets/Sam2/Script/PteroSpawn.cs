using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class PteroSpawn : MonoBehaviour
{
    //param
    float mobCap = 3;
    float singleMobCap = 1;
    float randomSide = 1;
    public float mobCount = 0;
    public float pteroCount = 0;
    public float tripyCount = 0;
    public float trexCount = 0;
    public bool hasAppeared = false;
    [SerializeField] GameObject pterodactylMob;
    [SerializeField] GameObject tripyMob;
    [SerializeField] GameObject veloMob;
    GameObject buffer;
    float decompte = 60;
    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        decompte -= Time.deltaTime;
        Debug.Log(mobCount);

        float randomDyno = UnityEngine.Random.Range(1, 9);

        if (decompte < 55 && mobCount < mobCap && randomDyno < 3 && pteroCount < singleMobCap)// PTERODACTYL
        {
            pterodactylMob.GetComponent<PteroMove>().spawner = this.gameObject;
            buffer = pterodactylMob;

            float randomSide = UnityEngine.Random.Range(0, 2);
            if (randomSide >= 1)
            {
                Vector2 randomPos = new Vector2(UnityEngine.Random.Range(9, 11), UnityEngine.Random.Range(2, 10));
                Instantiate(buffer, randomPos, Quaternion.identity);
            }
            if (randomSide < 1)
            {
                Vector2 randomPos = new Vector2(UnityEngine.Random.Range(-9, -11), UnityEngine.Random.Range(2, 10));
                Instantiate(buffer, randomPos, Quaternion.identity);
            }

            mobCount += 1;
            pteroCount++;
            
        }
        if (decompte < 58 && mobCount < mobCap && randomDyno > 3 && randomDyno < 6 && tripyCount < singleMobCap)// TRICERATOPS
        {
            tripyMob.GetComponent<TripyMove>().spawner = this.gameObject;
            buffer = tripyMob;

            float randomSide = UnityEngine.Random.Range(0, 2);
            if (randomSide >= 1)
            {
                Vector2 randomPosTripy = new Vector2(UnityEngine.Random.Range(9, 11), UnityEngine.Random.Range(-4, 4));
                Instantiate(buffer, randomPosTripy, Quaternion.identity);
            }
            if (randomSide < 1)
            {
                Vector2 randomPosTripy = new Vector2(UnityEngine.Random.Range(-9, -11), UnityEngine.Random.Range(-4, 4));
                Instantiate(buffer, randomPosTripy, Quaternion.identity);
            }

            mobCount += 1;
            tripyCount++;
        }
        if (decompte < 50 && mobCount < mobCap && randomDyno > 6 && trexCount < singleMobCap)// T REX
        {
            veloMob.GetComponent<TrexMove>().spawner = this.gameObject;
            buffer = veloMob;

            Vector2 randomPosVelo = new Vector2(UnityEngine.Random.Range(-7,7), UnityEngine.Random.Range(7,8));

            Instantiate(buffer, randomPosVelo, Quaternion.identity);
            mobCount++;
            trexCount++;
        }
        if (decompte < 40 && decompte > 30)
        {
            mobCap = 5;
            singleMobCap = 2;
        }
        if (decompte < 30 && decompte > 15)
        {
            mobCap = 7;
            singleMobCap = 4;
        }
        if (decompte < 15 && decompte > 1)
        {
            mobCap = 9;
        }

    }
}

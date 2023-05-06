using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ClementineComponent : MonoBehaviour
{
    float distance;
    float speed;
    public Vector3 spawnPoint;
    public int inc;
    public bool followTarget;
    [SerializeField] GameObject player,pouf;
    public GameObject target;
    bool catchSt;

    private void Start()
    {
        followTarget = false;
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 0;
        catchSt= false;
    }


    // Update is called once per frame
    void Update()
    {
        //Chute
        if(inc != -1 && !catchSt)
        {
            distance = transform.position.y - spawnPoint.y;
            if (distance > 0 && inc == 0)
            {
                this.transform.Translate(Vector3.down * Time.deltaTime * speed);
                speed += Time.deltaTime*3;
            }
            else if(inc == 0)
            {
                inc = 1;
                speed = 0.5f*speed;
            }

            if (inc == 1)
            {
                this.transform.Translate(Vector3.up * Time.deltaTime * speed);
                speed -= Time.deltaTime*5;
                if (speed < 0) inc = 2;
            }
            else if(inc == 1)
            {
                inc = 2;
            }

            if (distance > 0 && inc == 2)
            {
                this.transform.Translate(Vector3.down * Time.deltaTime * speed);
                speed += Time.deltaTime * 4;
            }
            else if (inc == 2)
            {
                inc = -1;
                this.transform.position = spawnPoint;
            }
        }

        //Lancer en l'air
        if(inc == -2)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * 20);
            if(this.tag == "Finish") this.tag = null;
        }

        //Suivi du joueur
        if (followTarget)
        {
            if(target == null)
            {
                inc = -2;
            }
            else
            {
                Vector3 dir = target.transform.position - transform.position;
                if (dir.magnitude > 0.25)
                {
                    transform.Translate(dir.normalized * 5 * Time.deltaTime);
                }
                
            }
            
        }

        //destroy trop haut
        if(transform.position.y > 30)
        {
            Destroy(this.gameObject);
        }
    }

    public void disparition()
    {
        Instantiate(pouf,transform.position,quaternion.identity);
        player.transform.GetChild(0).GetComponent<ClemMan>().DestroyQueue();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !catchSt)
        {
            followTarget = true;
            target = collision.gameObject.transform.GetChild(0).GetComponent<ClemMan>().assign(this.gameObject);
            catchSt= true;
        }
        if(collision.tag == "Ptero")
        {
            if (catchSt) 
            {
                player.transform.GetChild(0).GetComponent<ClemMan>().DestroyQueue();
            }
            else
            {
                inc= -2;
            }
            
        }
    }

}

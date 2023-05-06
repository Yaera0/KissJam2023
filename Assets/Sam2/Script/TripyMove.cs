using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripyMove : MonoBehaviour
{
    //param
    public GameObject spawner;
    float speed = 3f;
    bool goingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        if(this.transform.position.x < 1)
        {
            goingLeft = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (goingLeft)
        {

            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (this.transform.position.x < -10 || this.transform.position.y < -7)
            {
                spawner.GetComponent<PteroSpawn>().mobCount--;
                spawner.GetComponent<PteroSpawn>().tripyCount--;
                Destroy(this.gameObject);

            }
        }
        if (goingLeft == false)
        {

            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (this.transform.position.x > 10 || this.transform.position.y < -7)
            {
                spawner.GetComponent<PteroSpawn>().mobCount--;
                spawner.GetComponent<PteroSpawn>().tripyCount--;
                Destroy(this.gameObject);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rocher" || collision.tag == "Arbre")
        {
            goingLeft = !goingLeft;
            if(goingLeft == false)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}

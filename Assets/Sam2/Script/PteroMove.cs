using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PteroMove : MonoBehaviour
{
    //param
    public GameObject spawner;
    float speed = 5f;
    float speedDown = 3f;
    bool goingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.position.x < 1)
        {
            goingLeft = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goingLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.Translate(Vector2.down * speedDown * Time.deltaTime);
            if (this.transform.position.x < -10 || this.transform.position.y < -7)
            {
                spawner.GetComponent<PteroSpawn>().mobCount--;
                spawner.GetComponent<PteroSpawn>().pteroCount--;
                Destroy(this.gameObject);
            }
        }
        if (!goingLeft)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.Translate(Vector2.down * speedDown * Time.deltaTime);
            if (this.transform.position.x > 10 || this.transform.position.y < -7)
            {
                spawner.GetComponent<PteroSpawn>().mobCount--;
                spawner.GetComponent<PteroSpawn>().pteroCount--;
                Destroy(this.gameObject);
            }
        }
    }
}

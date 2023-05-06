using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeloMove : MonoBehaviour
{
    //param
    public GameObject spawner;
    float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (this.transform.position.x < -10 || this.transform.position.y < -7)
        {
            spawner.GetComponent<PteroSpawn>().mobCount--;
            Destroy(this.gameObject);

        }
    }
}

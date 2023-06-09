using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexMove : MonoBehaviour
{
    //Instantiate
    [SerializeField] GameObject pouf;
    //param
    public GameObject spawner;
    public float factorSpeed;
    float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * factorSpeed * speed * Time.deltaTime);
        if (this.transform.position.x < -10 || this.transform.position.y < -7)
        {
            spawner.GetComponent<PteroSpawn>().mobCount--;
            spawner.GetComponent<PteroSpawn>().trexCount--;
            Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arbre" || collision.tag == "Rocher")
        {
            //Animation Crash
            spawner.GetComponent<PteroSpawn>().mobCount--;
            spawner.GetComponent<PteroSpawn>().trexCount--;
            Instantiate(pouf, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }
        else if (collision.tag == "Lac")
        {
            //Animation Noyade
            spawner.GetComponent<PteroSpawn>().mobCount--;
            spawner.GetComponent<PteroSpawn>().trexCount--;
            Destroy(this.gameObject);
        }
    }
}

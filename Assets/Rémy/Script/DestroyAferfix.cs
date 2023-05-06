using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAferfix : MonoBehaviour
{

    [SerializeField] float delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("coroutine");
    }

    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDestroy : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Destroy(this.gameObject);
        }
    }
}

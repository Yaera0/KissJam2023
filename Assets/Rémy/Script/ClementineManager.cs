using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClementineManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ClementinePos = new List<GameObject>();
    [SerializeField] GameObject clementineQuarterPrefab;
    GameObject buffer;

    //param
    public bool canAppear = true;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    
}

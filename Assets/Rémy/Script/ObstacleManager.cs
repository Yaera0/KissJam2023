using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            float random = Random.Range(0.0f, 1.0f);
            if(random > 0.4f)
            {
                GameObject buffer = obstacles[Mathf.RoundToInt(Random.Range(0,obstacles.Count))];
                Instantiate(buffer, child.transform);
            }
        }



    }

}

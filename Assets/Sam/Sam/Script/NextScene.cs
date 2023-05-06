using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    float a;
    bool once;
    [SerializeField] int nextIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        once = true;
        a = 0.72f;
    }

    private void Update()
    {
        a -= Time.deltaTime;
        if (a < 0f) SceneManager.LoadScene(nextIndex);
    }


}

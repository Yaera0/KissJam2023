using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameOver : MonoBehaviour
{

    public bool GameOver;
    bool ones;
    float alpha;
    Color baseColor;
    [SerializeField] GameObject canvasGameOver;
    // Start is called before the first frame update
    void Start()
    {
        alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameOver)
        {
            if (!ones)
            {
                ones = true;
                canvasGameOver.SetActive(true);
            }
            baseColor = Color.red;
            baseColor.a = alpha;
            canvasGameOver.transform.GetChild(0).GetComponent<Image>().color = baseColor;
            if (alpha< 0.5)
            {
                alpha += Time.deltaTime * 0.1f;
            }
            else
            {
                SceneManager.LoadScene(5);
            }
           


        }
    }
}

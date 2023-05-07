using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimManager : MonoBehaviour
{
    [SerializeField] GameObject canvaAfter;
    [SerializeField] GameObject Anime;
    [SerializeField] GameObject flou;
    bool flouB;
    Color flouC;
    [SerializeField] float buf;
    // Start is called before the first frame update
    void Start()
    {
        buf = 1;
        flouB= false;
        canvaAfter.SetActive(false);
        Anime.SetActive(true);
        StartCoroutine("AnimDelay");
    }
    IEnumerator AnimDelay()
    {
        yield return new WaitForSeconds(0.73f);
        canvaAfter.SetActive(true);
        Anime.SetActive(false);
        flouB = true;
        flouC = flou.GetComponent<Image>().color;
        flou.GetComponent<Image>().color = flouC;
    }

    // Update is called once per frame
    void Update()
    {
        if (flouB)
        {
            
            if (flouC.a <= 0)
            {
                flouB= false;
            }
            else
            {
                
                flouC.a = buf;
                buf -= Time.deltaTime / 5;
                try
                {
                    flou.GetComponent<Image>().color = flouC;
                }
                catch
                {
                    flouB = false;
                }
            }
            
        }
    }
}

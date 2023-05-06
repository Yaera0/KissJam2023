using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManagement : MonoBehaviour
{
    public float difficultyLevel;
    [SerializeField] Sprite difficultylevel1;
    [SerializeField] Sprite difficultylevel2;
    [SerializeField] Sprite difficultylevel3;
    [SerializeField] Sprite difficultylevel1v2;
    [SerializeField] Sprite difficultylevel2v2;
    [SerializeField] Sprite difficultylevel3v2;


    // Start is called before the first frame update
    void Start()
    {
        difficultyLevel = 1;
    }


    public void ChangeDifficulty()
    {
        if (difficultyLevel < 3)
        {
            difficultyLevel++;
        }
        else
        {
            difficultyLevel = 1;
        }
        if(difficultyLevel == 1)
        {
            SpriteState ss = new SpriteState();
            ss.highlightedSprite = difficultylevel1v2;
            this.gameObject.GetComponent<Button>().image.sprite = difficultylevel1;
            this.gameObject.GetComponent<Button>().spriteState = ss;
        }
        if(difficultyLevel == 2)
        {
            SpriteState ss = new SpriteState();
            ss.highlightedSprite = difficultylevel2v2;
            this.gameObject.GetComponent<Button>().image.sprite = difficultylevel2;
            this.gameObject.GetComponent<Button>().spriteState = ss;
        }
        if(difficultyLevel == 3)
        {
            SpriteState ss = new SpriteState();
            ss.highlightedSprite = difficultylevel3v2;
            this.gameObject.GetComponent<Button>().image.sprite = difficultylevel3;
            this.gameObject.GetComponent<Button>().spriteState = ss;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayOptions : MonoBehaviour
{
    public float difficulty = 1;

    // Start is called before the first frame update
    void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        difficulty++;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

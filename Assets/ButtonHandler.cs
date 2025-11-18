using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Image p1;
    public Image enemy;

    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;

    Dictionary<string, Sprite> possibleChoice = new Dictionary<string, Sprite>{};
    


    // Start is called before the first frame update
    void Start()
    {
        possibleChoice["rock"] = rock;
        possibleChoice["paper"] = paper;
        possibleChoice["scissors"] = scissors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rockButtonClick()
    {
        p1.sprite = possibleChoice["rock"];
        Debug.Log("Rock button cliked");

    }
    public void paperButtonClick()
    {
        p1.sprite = possibleChoice["paper"];
        Debug.Log("Paper button cliked");
    }
    public void scissorsButtonClick()
    {
        p1.sprite = possibleChoice["scissors"];
        Debug.Log("Scissors button cliked");
    }

    
}

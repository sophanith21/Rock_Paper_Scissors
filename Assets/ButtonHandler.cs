using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public Image p1;
    public Image Computer;

    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;
    
    public ComputerAI computerAI;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rockButtonClick()
    {
        p1.sprite = rock;
        Debug.Log("Rock button cliked");
        computerAI.getUserInput(0);
    }
    public void paperButtonClick()
    {
        p1.sprite = paper;
        Debug.Log("Paper button cliked");
        computerAI.getUserInput(1);
    }
    public void scissorsButtonClick()
    {
        p1.sprite = scissors;
        Debug.Log("Scissors button cliked");
        computerAI.getUserInput(2);
    }

    
}

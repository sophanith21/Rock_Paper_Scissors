using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [Header("UI Elements")]
    public Image p1;
    public Image Computer;

    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;
    
    [Header("AI Settings")]
    public ComputerAI computerAI;

    [Header("Score Settings")]
    public ScoreSystem scoreSystem;

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
        int input = 0;
        p1.sprite = rock;
        Debug.Log("Rock button cliked");
        computerAI.getUserInput(input);
        scoreSystem.getPlayerChoice(input);
    }
    public void paperButtonClick()
    {
        int input = 1;
        p1.sprite = paper;
        Debug.Log("Paper button cliked");
        computerAI.getUserInput(input);
        scoreSystem.getPlayerChoice(input);
    }
    public void scissorsButtonClick()
    {
        int input = 2;
        p1.sprite = scissors;
        Debug.Log("Scissors button cliked");
        computerAI.getUserInput(input);
        scoreSystem.getPlayerChoice(input);
    }

    
}

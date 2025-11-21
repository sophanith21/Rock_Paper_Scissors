
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

    int roundsToEnd;

    // Start is called before the first frame update
    void Start()
    {
       roundsToEnd = PlayerPrefs.GetInt("roundsToEnd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rockButtonClick()
    {
        if (computerAI.numTurn <= roundsToEnd)
        {
            int input = 0;
            p1.sprite = rock;

            SoundManager.Instance.PlayClick();

            computerAI.getUserInput(input);
            scoreSystem.getPlayerChoice(input);
        }
        
    }
    public void paperButtonClick()
    {
        if (computerAI.numTurn <= roundsToEnd)
        {
            int input = 1;
            p1.sprite = paper;

            SoundManager.Instance.PlayClick();
            computerAI.getUserInput(input);
            scoreSystem.getPlayerChoice(input);
        }
    }
    public void scissorsButtonClick()
    {
        if (computerAI.numTurn <= roundsToEnd)
        {
            int input = 2;
            p1.sprite = scissors;

            SoundManager.Instance.PlayClick();
            computerAI.getUserInput(input);
            scoreSystem.getPlayerChoice(input);
        }
    }

    public void backButtonClick()
    {

        SceneSwitcher.Instance.toMain();
    }
    
}

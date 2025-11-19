using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text player;
    public TMP_Text computer;

    public ComputerAI computerAI;

    int playerScore = 0;
    int computerScore = 0;

    int? playerChoice;
    int? computerChoice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateScore()
    {
        if (playerChoice.HasValue && computerChoice.HasValue)
        {
            int computerChoice = this.computerChoice.Value;
            int playerChoice = this.playerChoice.Value;

            if (playerChoice == ComputerAI.getCounterIndex(computerChoice))
            {
                playerScore++;
            }
            else if (computerChoice == ComputerAI.getCounterIndex(playerChoice))
            {
                computerScore++;
            }

            player.text = playerScore.ToString();

            computer.text = computerScore.ToString();

            this.playerChoice = null;
            this.computerChoice = null;
        }
    }
    public void getPlayerChoice(int choice)
    {
        playerChoice = choice;
        updateScore();
    }

    public void getComputerChoice(int choice)
    {
        computerChoice = choice;
        updateScore();
    }
}

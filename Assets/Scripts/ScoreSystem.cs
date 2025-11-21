using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text player;
    public TMP_Text computer;

    [Header("AI Settings")]
    public ComputerAI computerAI;

    int playerScore = 0;
    int computerScore = 0;

    int? playerChoice;
    int? computerChoice;

    int roundsToEnd;
    // Start is called before the first frame update
    void Start()
    {
        roundsToEnd = PlayerPrefs.GetInt("roundsToEnd");
    }

    // Update is called once per frame
    void Update()
    {
        if (computerAI.numTurn > roundsToEnd && !computerAI.isShuffling)
        {
            if (playerScore > computerScore)
            {
                SceneSwitcher.Instance.LoadScene("Winning");
            }
            else if (computerScore > playerScore)
            {
                SceneSwitcher.Instance.LoadScene("GameOver");
            }
            else
            {
                SceneSwitcher.Instance.LoadScene("DrawScene");
            }
        }
    }
    void updateScore()
    {
        if (playerChoice.HasValue && computerChoice.HasValue)
        {
            int computerChoice = this.computerChoice.Value;
            int playerChoice = this.playerChoice.Value;

            if (playerChoice == ComputerAI.getCounterIndex(computerChoice))
            {
                SoundManager.Instance.PlayWin();
                playerScore++;
            }
            else if (computerChoice == ComputerAI.getCounterIndex(playerChoice))
            {
                SoundManager.Instance.PlayLose();
                computerScore++;
            }
            else
            {
                SoundManager.Instance.PlayDraw();
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

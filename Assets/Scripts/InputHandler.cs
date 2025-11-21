
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class InputHandler : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField normalInputField;
    public TMP_InputField advancedInputField;
    

    [Header("Game Settings")]
    public int minimumNormalRound = 10;
    public int minimumAdvancedRound = 10;


    TMP_Text advancedPlaceholderInput;
    TMP_Text normalPlaceholderInput;

    private void Start()
    {
        normalPlaceholderInput = normalInputField.placeholder.GetComponent<TMP_Text>();
        advancedPlaceholderInput = advancedInputField.placeholder.GetComponent<TMP_Text>();
    }

    public void checkNumber()
    {    
        if (HandleNumMode.isNormal)
        {
            string userInput = normalInputField.text;
            
            int number;

            // Try to parse the string to int  
            if (int.TryParse(userInput, out number))
            {
                number = Mathf.Min(number, 999); 
                PlayerPrefs.SetInt("roundsToEnd", number);
                PlayerPrefs.Save();
                if (number >= minimumNormalRound)
                {
                    Debug.Log("Correct!");

                    //to next scene Normal Mode
                    HandleNumMode.isNormal = false;
                    SceneSwitcher.Instance.LoadScene("RandomMode");
                }
                else
                {
                    normalInputField.text = "";
                    normalPlaceholderInput.text =minimumNormalRound + " or higher";
                }
            }
            else
            {
                Debug.Log("Please enter a valid number!");
            }

        }
        else if (HandleNumMode.isAdvance)
        {
            string userInput = advancedInputField.text;
            int number;

            if (int.TryParse(userInput, out number))
            {
                number = Mathf.Min(number, 999);
                PlayerPrefs.SetInt("roundsToEnd", number);
                PlayerPrefs.Save();
                if (number >= minimumAdvancedRound)
                {
                    Debug.Log("Correct!");

                    //to next scene Advance Mode
                    HandleNumMode.isAdvance = false;
                    SceneSwitcher.Instance.LoadScene("AdvancedComputerMode");
                }
                else
                {
                    advancedInputField.text = "";
                    advancedPlaceholderInput.text = minimumAdvancedRound + " or higher";
                }
            }
            else
            {
                Debug.Log("Please enter a valid number!");
            }
        }
       

    }
       
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InputHandler : MonoBehaviour
{
    public InputField inputField;
    public int targetNumber = 10;

    public void checkNumber()
    {
        string userInput = inputField.text;
        int number;

        // Try to parse the string to int safely
        if (int.TryParse(userInput, out number))
        {
            if (number > targetNumber)
            {
                Debug.Log("Correct!");

                if (targetNumber == 10)
                {
                    //to next scene Normal Mode
                    SceneManager.LoadScene("RandomMode");

                }
                else
                {
                    //to next scene Advance Mode
                    SceneManager.LoadScene("AdvancedComputerMode");
                }
            }
            else
            {
                Debug.Log("Wrong number!");
            }
        }
        else
        {
            Debug.Log("Please enter a valid number!");
        }
    }
}

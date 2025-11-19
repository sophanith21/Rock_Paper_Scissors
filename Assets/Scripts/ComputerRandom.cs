using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComputerRandom : MonoBehaviour
{
    [Header("UI Elements")]
    public Image computer;
    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;

    public TMP_Text turnNumber;

    [Header("Score Settings")]
    public ScoreSystem scoreSystem;

    Dictionary<int,Sprite> map = new Dictionary<int, Sprite> ();

    int currentInput;

    int numTurn = 1;

    // Start is called before the first frame update
    void Start()
    {
        map[0] = rock;
        map[1] = paper;
        map[2] = scissors;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void getUserInput(int input)
    {
        currentInput = input;
        int computerChoice;
        
        numTurn ++;

        

        computerChoice = UnityEngine.Random.Range(0, 3);
        
        computer.sprite = map[computerChoice];
        scoreSystem.getComputerChoice(computerChoice);

        turnNumber.text = "TURN " + numTurn.ToString() ; 
    }

    void normalizedRowVector(float [] rowVectorCount, float [] rowVectorProb)
    {
        float sum = rowVectorCount[0] + rowVectorCount[1] + rowVectorCount[2];
        if (sum > 0)
        {
            for (int i = 0 ; i < 3; i++)
            {
                rowVectorProb[i] = rowVectorCount[i] / sum;
            }
        }
    }

   

    int getMaxIndex(float [] vector)
    {
        int currentMaxIndex = 0;
        for (int i = 0 ; i < 3 ; i++)
        {
            if (vector[i] > vector[currentMaxIndex])
            {
                currentMaxIndex = i;
            }
        }
        return currentMaxIndex;
    }

    static public int getCounterIndex(int predictedIndex)
    {
        if (predictedIndex == 0)
        {
            return 1;
        } 
        else if (predictedIndex == 1)
        {
            return 2;
        } 
        else
        {
            return 0;
        }
    }
}

using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComputerAI : MonoBehaviour
{
    [Header("UI Elements")]
    public Image computer;
    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;

    public TMP_Text turnNumber;

    [Header("AI Settings")]
    public int startPredictV1 = 11;
    public int startPredictV2 = 31;

    [Header("Score Settings")]
    public ScoreSystem scoreSystem;
    
    Dictionary<int,Sprite> map = new Dictionary<int, Sprite> ();

    // First Order Markov Model (Intended for use from turn 11 => 30)
    float[][] transitionMatrixCount = new float[][]
    {
        new float[] {0, 0, 0},
        new float[] {0, 0, 0},
        new float[] {0, 0, 0}
    };
    float [][] transitionMatrixProb = new float[][]
    {
        new float[] {0, 0, 0},
        new float[] {0, 0, 0},
        new float[] {0, 0, 0}
    };


    // Second Order Markov Model (Intended for use from turn 31 up )
    float[][][] transitionMatrixCount2 = new float[][][]
    {
        new float[][]
        {
            new float[] {0, 0, 0},
            new float[] {0, 0, 0},
            new float[] {0, 0, 0}
        },
        new float[][]
        {
            new float[] {0, 0, 0},
            new float[] {0, 0, 0},
            new float[] {0, 0, 0}
        },
        new float[][]
        {
            new float[] {0, 0, 0},
            new float[] {0, 0, 0},
            new float[] {0, 0, 0}
        }
    };
    
    float[][][] transitionMatrixProb2 = new float[][][]
    {
       new float[][]
        {
            new float[] {0, 0, 0},
            new float[] {0, 0, 0},
            new float[] {0, 0, 0}
        },
        new float[][]
        {
            new float[] {0, 0, 0},
            new float[] {0, 0, 0},
            new float[] {0, 0, 0}
        },
        new float[][]
        {
            new float[] {0, 0, 0},
            new float[] {0, 0, 0},
            new float[] {0, 0, 0}
        }
    };


    int currentInput;
    int prevInput;
    int secondPrevInput;

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

        if (numTurn > 1 && numTurn < startPredictV2)
        {
            transitionMatrixCount[prevInput][currentInput] += 1;
            normalizedRowVector(transitionMatrixCount[prevInput], transitionMatrixProb[prevInput]);
        }

        if (numTurn > 2)
        {
            transitionMatrixCount2[secondPrevInput][prevInput][currentInput] += 1;
            normalizedRowVector(transitionMatrixCount2[secondPrevInput][prevInput], transitionMatrixProb2[secondPrevInput][prevInput]);
        }
        
        numTurn ++;

        if (numTurn == startPredictV2 )
        {
            Debug.Log("Second Order Markov Model Activated");

            // Optomize memory usage since it is no longer needed
            transitionMatrixProb = null;
            transitionMatrixCount = null;
        }
        else if (numTurn == startPredictV1)
        {
            Debug.Log("First Order Markov Model Activated");
        }

        if (numTurn >= startPredictV1 && numTurn < startPredictV2)
        {

            Debug.Log(string.Join(", ", transitionMatrixProb[prevInput]));

            int predictedIndex = getMaxIndex(transitionMatrixProb[prevInput]);
            computerChoice = getCounterIndex(predictedIndex);
        }
        else if (numTurn >= startPredictV2)
        {
            Debug.Log(string.Join(", ", transitionMatrixProb2[secondPrevInput][prevInput]));

            int predictedIndex = getMaxIndex(transitionMatrixProb2[secondPrevInput][prevInput]);
            computerChoice = getCounterIndex(predictedIndex);

        }
        else
        {
            computerChoice = UnityEngine.Random.Range(0, 3);
        }

        computer.sprite = map[computerChoice];
        scoreSystem.getComputerChoice(computerChoice);

        secondPrevInput = prevInput;
        prevInput = currentInput;
        turnNumber.text = "TURN " + (numTurn).ToString() ; 
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

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComputerAI : MonoBehaviour
{
    public Image computer;
    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;

    public int startPredict = 10;

    
    Dictionary<int,Sprite> map = new Dictionary<int, Sprite> ();
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

    float [] currentStateVector = new float [] {1/3f,1/3f,1/3f};
    int prevInput;

    int numTurn = 0;
    int prevNumTurn = 0;
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
        if (numTurn > prevNumTurn)
        {
            prevNumTurn++;
            if (numTurn >= startPredict)
            {
                for (int i = 0 ; i < 3; i++)
                {
                    normalizedRowVector(transitionMatrixCount[i],transitionMatrixProb[i]);
                }

                float [] nextStateVector = new float [] {0,0,0};
                matrixMultiplication(currentStateVector,transitionMatrixProb,nextStateVector);

                Debug.Log(string.Join(", ", nextStateVector));

                int predictedIndex = getMaxIndex(nextStateVector);
                int computerChoice = getCounterIndex(predictedIndex);

                computer.sprite = map[computerChoice];
                Array.Copy(nextStateVector,currentStateVector,3);
            }
            else
            {
                computer.sprite = map[UnityEngine.Random.Range(0,3)];
            }
        }
    }

    public void getUserInput(int currentInput)
    {
        if (numTurn != 0)
        {
            transitionMatrixCount[prevInput][currentInput] += 1;
        }
        prevInput = currentInput;
        numTurn ++;
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

    void matrixMultiplication(float [] currentStateVector, float [][] transitionMatrixProb, float [] nextStateVector)
    {
        for (int i = 0; i < 3; i++)
        {
            nextStateVector[i] = 0.0f;
            for (int j = 0; j < 3; j++)
            {
                nextStateVector[i] += currentStateVector[j] * transitionMatrixProb[j][i];
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

    int getCounterIndex(int predictedIndex)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCheck : MonoBehaviour
{
    public bool checkinitial;
    public int[] intialPos = new int[5];
    private int[] arr = new int[5];
    int[] solution = new int[1000];
    int moveStep;
    int move;
    int checkMove;
    int checkcorrectIn;
    public bool isSort = false;

    public GameObject gameData;

    private HandData handData;

   
    // Start is called before the first frame update
    void Start()
    {
        handData = gameData.GetComponent<HandData>();
        checkMove = 0;
        checkcorrectIn = 0;
        checkinitial = false;
        intialPosition();
        Debug.Log(checkinitial);
        insertionSorting();
        printArray();

    }

    // Update is called once per frame
    void Update()
    {
        if(checkinitial == false )
        {
            intialPosition();
            Debug.Log(checkinitial);
            insertionSorting();
            printArray();
        }
    }
    public void intialPosition()
    {
        Debug.Log("Enter");
        int tmp = 0;
        intialPos = handData.handData;

        for (int i = 0; i < intialPos.Length; i++)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                if (i == j)
                {
                    arr[j] = intialPos[i];
                    //Debug.Log(arr[j]);
                }
            }
            if (intialPos[i] != 0)
            {
                tmp++;
                //Debug.Log(intialPos[i]);
            }
        }
        if (tmp != 5)
        {
            checkinitial = false;
        }
        else
        {
            checkinitial = true;
        }

    }

    public void insertionSorting()
    {
        int key, i, j;
        for (i = 1; i < arr.Length; i++)
        {
            key = arr[i];
            j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
            moveStep++;
            for(j = 0; j < arr.Length;j++)
            {
                solution[i * arr.Length + j] = arr[j];
            }
        }
        Debug.Log(moveStep);
    }

    public void printArray()
    {
        for (int j = 0; j < arr.Length; j++)
        {
            Debug.Log(arr[j]);
        }
    }

   public void checkInsertSort()
   {
        move = handData.moveCount;
        for(int i = 0; i < 5 ; i++)
        {
            if(arr[move*5+i] == handData.handData[i])
            {
                checkcorrectIn++;
            }
        }
        if(checkcorrectIn == 5)
        {
            checkMove++;
        }
        else
        {
            checkMove = 0;
        }
        if(checkMove == moveStep)
        {
            isSort = true;
            handData.score += 4 * 1.5 * 0.85;
            checkMove = 0;
        }
        else
        {
            isSort = false;
        }
   }

}

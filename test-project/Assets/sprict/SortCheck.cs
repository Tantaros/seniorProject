using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCheck : MonoBehaviour
{
    public bool checkinitial;
    public int[] intialPos = new int[5];
    private int[] arr = new int[5];
    public int[,] solution = new int[100,100];
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
        //printArray();

    }

    // Update is called once per frame
    void Update()
    {
        if(checkinitial == false )
        {
            intialPosition();
            Debug.Log(checkinitial);
            insertionSorting();
            //printArray();
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
        moveStep = 0;
        for (i = 1; i < arr.Length; i++)
        {
            key = arr[i];
            j = i - 1;
            if (j >= 0 && arr[j] > key)
            {
                moveStep++;
            }

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
            
            for(j = 0; j < arr.Length;j++)
            {
                solution[moveStep,j] = arr[j];
                Debug.Log(moveStep + "-"+ solution[moveStep , j]);
            }
        }
        handData.movestep_insertsort = moveStep;
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
        for(int i = 0; i < 5 ; i++)
        {
            if ( solution[move,i] == handData.handData[i])
            {
                checkcorrectIn++;
                Debug.Log("in");
            }
        }
        if(checkcorrectIn == 5)
        {
            checkMove++;
            checkcorrectIn = 0;
            Debug.Log("Sort"+checkMove);
        }
        else
        {
            checkcorrectIn = 0;
        }
        if(checkMove == moveStep)
        {
            isSort = true;
            Debug.Log("inseno");
            handData.score += (50);
            checkMove = 0;
        }
        else
        {
            isSort = false;
            checkMove = 0;
        }
   }

}

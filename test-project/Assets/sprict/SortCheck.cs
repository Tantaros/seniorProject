using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortCheck : MonoBehaviour
{
    public bool checkinitial;
    public int[] intialPos = new int[5];
    private int[] arr = new int[5];
    //public int[,] solution = new int[100,100];
    int moveStep;
    int move;
    int checkMove;
    int checkcorrectIn;
    public bool isSort = false;
    public bool ss = true;

    float delay;
    public Canvas inseno;

    public GameObject gameData;
    private HandData handData;

    
    // Start is called before the first frame update
    void Start()
    {
        handData = gameData.GetComponent<HandData>();
        checkMove = 0;
        checkcorrectIn = 0;
        move = 1;
        checkinitial = false;
        intialPosition();
        Debug.Log(checkinitial);
        insertionSorting();
        //printArray();
        delay = 0.6f;
        inseno.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (checkinitial == false )
        {
            intialPosition();
            Debug.Log("checkinitial = " + checkinitial);
            insertionSorting();
            //printArray();
            ss = true;
            delay = 0.6f;

        }
        if (isSort == true && ss)
        {
            //Debug.Log("delay");
            delay -= Time.deltaTime;
            if (delay < 0.5f)
            {
                inseno.gameObject.SetActive(true);
            }
            if (delay <= 0.1f)
            {
                inseno.gameObject.SetActive(false);
               
                isSort = false;
                
            }
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
                handData.solution[moveStep,j] = arr[j];
                Debug.Log(moveStep + "-"+ handData.solution[moveStep , j]);
            }
        }
        handData.movestep_insertsort = moveStep;
        Debug.Log("moveStep = " + moveStep);
        Debug.Log("handData.movestep_insertsort ="+ handData.movestep_insertsort);
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
       
        for (int i = 0; i < 5 ; i++)
        {
            if (handData.solution[move,i] == handData.handData[i])
            {
                checkcorrectIn++;
                
            }
        }
        move++;
        Debug.Log("move ="+ move);
        Debug.Log("checkcorrectIn ="+checkcorrectIn);
        if(checkcorrectIn == 5)
        {
            Debug.Log("before checkMove =" + checkMove);
            checkMove++;
            checkcorrectIn = 0;
            Debug.Log("after checkMove = " + checkMove);

        }
        else
        {
            checkcorrectIn = 0;
            move = 1;
            checkMove = 0;
        }
        if(checkMove == moveStep)
        {
            isSort = true;
            Debug.Log("isSort =" + isSort);
            Debug.Log("inseno");
            handData.score += (30);
            checkMove = 0;
            move = 1;
            Debug.Log("after inseono, move =" + move);
        }
        else
        {
            isSort = false;
            
        }
        
   }

    
}

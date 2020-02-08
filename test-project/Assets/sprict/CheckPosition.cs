using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CheckPosition : MonoBehaviour
{
    public bool[] checkPos = new bool[5];
    public int countCorrect;
    bool checkinitial;
    //public int[] intialPos = new int[5];
    public int[] finalPos = new int[5];
    private bool[] arr = new bool[5];
    
    int moveStep;
    
    

    
    //public int[,] solution = new int[100, 100];
    int[] bb = new int[5];
    int move;
    int checkMove;
    int checkcorrectIn;
    public bool isSort;

    public Text ScoreText;

    public GameObject gameData;
    private HandData handData;

    //public GameObject sort;
    //private SortCheck sortCheck;
 
    //public List<GameObject> handata;
    // Start is called before the first frame update
    void Start()
    {
        handData = gameData.GetComponent<HandData>();
        //sortCheck = gameData.GetComponent<SortCheck>();
        move = 1;
        //SetText();
    }

    // Update is called once per frame
    void Update()
    {
        //SetText();
        
    }


    public void checkCurrentPosition()
    {
        countCorrect = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            //Debug.Log("hi");
            if (finalPos[i] == handData.handData[i])
            {
                checkPos[i] = true;
            }
            else
            {
                checkPos[i] = false;
            }
        }
        
        for ( int i= 0;i< transform.childCount; i++){

            if (checkPos[i] == true )
            {
                countCorrect++;
            }
        }
        Debug.Log(!handData.old_handdata.SequenceEqual(handData.handData));
        if (!handData.old_handdata.SequenceEqual(handData.handData))
        {
            //Debug.Log("eee");
            setold_handdata();
            //handData.score += 5 ;
            if (countCorrect == 5)
            {
                handData.score += 7;

                handData.reSpawnCheck = true;
            }
        }
       
        
        //Debug.Log(countCorrect); 

    }
    
    void SetText()
    {
        ScoreText.text =  handData.score.ToString("f0");
    }

    public void setold_handdata()
    {
        handData.old_handdata = handData.handData;
    }

    /*public void checkInsertSort()
    {
        for (int i = 0; i < 5; i++)
        {
            //Debug.Log(sortCheck.solution[move, i]);
            if (handData.solution[move, i] == handData.handData[i])
            {
                checkcorrectIn++;
                Debug.Log("in");
            }
        }
        if (checkcorrectIn == 5)
        {
            checkMove++;
            checkcorrectIn = 0;
            move++;
            Debug.Log("Sort" + checkMove);
        }
        else
        {
            checkcorrectIn = 0;
            move = 0;
        }
        if (checkMove == handData.movestep_insertsort )
        {
            Debug.Log("inseno");
            delay -= Time.deltaTime;
            if (delay < 0.5f)
            {
                inseno.gameObject.SetActive(true);
            }
            if (delay <= 0.3f)
            {
                inseno.gameObject.SetActive(false);
                delay = 0.6f;
            }
            
            Debug.Log(checkMove);
            Debug.Log(moveStep);
            handData.score += (10);
            checkMove = 0;
        }
        else
        {
            Debug.Log(checkMove+"-");
            Debug.Log(moveStep + "-");
            Debug.Log("not inseno");
            checkMove = 0;
        }
    }*/

    /*public void insertionSorting()
    {
        int key, i, j;
        moveStep = 0;
        for (i = 1; i < arr.Length; i++)
        {
            key = bb[i];
            j = i - 1;
            if (j >= 0 && bb[j] > key)
            {
                moveStep++;
            }

            while (j >= 0 && bb[j] > key)
            {
                bb[j + 1] = bb[j];
                j = j - 1;
            }
            bb[j + 1] = key;

            for (j = 0; j < arr.Length; j++)
            {
                solution[i, j] = bb[j];
            }
        }
        handData.movestep_insertsort = moveStep;
        Debug.Log(moveStep);
    }*/

}

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
    public int[] intialPos = new int[5];
    public int[] finalPos = new int[5];
    private bool[] arr = new bool[5];
    int[] solution = new int[50];
    int moveStep;
    public bool reSpawnCheck;

    public Text ScoreText;

    public GameObject gameData;

    private HandData handData;


 
    //public List<GameObject> handata;
    // Start is called before the first frame update
    void Start()
    {
        handData = gameData.GetComponent<HandData>();
        
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        SetText();

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
        if (!handData.old_handdata.SequenceEqual(handData.handData))
        {
            setold_handdata();
            handData.score += 2 * 1.5 ;
        }
        if (countCorrect == 5)
        {
            handData.score += 2 * 1.5 * 2;

            reSpawnCheck = true;
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

    

}

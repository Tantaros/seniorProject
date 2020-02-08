using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandData : MonoBehaviour
{
    [Tooltip("Hand data")]
    public int[] handData;
    public int[] old_handdata;
    public double score;
    public int moveCount;
    public bool isWin;
    public float HPP;
    public float HPE;
    public int movestep_insertsort;
    public int[,] solution = new int[100, 100];
    public bool reSpawnCheck;
    private HorizontalLayoutGroup handLayoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
        score = 0;
        moveCount = 0;
        setold_handdata();
        reSpawnCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void setold_handdata()
    {
       old_handdata = handData;
    }

}

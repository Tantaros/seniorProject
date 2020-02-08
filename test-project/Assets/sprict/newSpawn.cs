using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class newSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    float delay;
    

    [Tooltip("Canvas to be the parent of spawned cards")]
    public Transform spawnTarget;

    [Tooltip("GameDataObject")]
    public GameObject gameData;

    private HandData handData;

    // Spawn Data
    public int[] spawnData;

    // Reference to card prefabs
    public List<GameObject> cardRef;

    public GameObject cardTemp;

    [Tooltip("check pos")]
    public GameObject checkPos;
    private CheckPosition reSwapn;

    public GameObject sort;
    private SortCheck SortCheck;

    void Start()
    {
        delay = 0.5f;
        handData = gameData.GetComponent<HandData>();
        Shuffle();
        spawnCardBySpawnData();
        setHandData();
        reSwapn = checkPos.GetComponent<CheckPosition>();
        SortCheck = sort.GetComponent<SortCheck>();
        if(reSwapn.finalPos == handData.handData)
        {
            clearBoard();
            Shuffle();
            spawnCardBySpawnData();
            setHandData();
        }
        //reSwapn.checkCurrentPosition();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        panel = obj.GetComponentsInChildren<Transform>();
        len = panel.Length;
        GameObject rand = panel[Random.Range(0,len)].gameObject;*/
        //reSpawn();
        //Debug.Log(reSwapn.reSpawnCheck);
        
        if (handData.reSpawnCheck == true || reSwapn.finalPos == handData.handData)
        {
            clearBoard();
            spawnCardTemp();
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                handData.reSpawnCheck = false;
                reSwapn.setold_handdata();
                SortCheck.checkinitial = false;
                SortCheck.isSort = false;
                Debug.Log("SortCheck.checkinitial : "+ SortCheck.checkinitial);
                clearBoard();
                Shuffle();
                spawnCardBySpawnData();
                setHandData();
                //checkPosition = checkPos.GetComponent<CheckPosition>();

                delay = 0.5f;
            }

        }

    }

    public void Shuffle()
    {
        int temp;
        for (int i = 0; i < spawnData.Length; i++)
        {
            int rnd = Random.Range(0, spawnData.Length);
            temp = spawnData[rnd];
            spawnData[rnd] = spawnData[i];
            spawnData[i] = temp;
        }
        
    }
    public void setHandData()
    {
        handData.handData = spawnData;

    }
    public void clearBoard()
    {
        for(int i =0; i < obj.transform.childCount ; i++)
        {
            Destroy(obj.transform.GetChild(i).gameObject);
        }
        for(int i = 0; i< reSwapn.checkPos.Length; i++)
        {
            reSwapn.checkPos[i] = false;
        }
    }

    public void spawnCardBySpawnData()
    {
        for(int i = 0; i < spawnData.Length; i++)
        {
            GameObject instantiatedCard;
            switch (spawnData[i])
            {
                case 1:
                    instantiatedCard = Instantiate(cardRef[0]);
                    instantiatedCard.transform.parent = spawnTarget;
                    
                    break;
                case 2:
                    instantiatedCard = Instantiate(cardRef[1]);
                    instantiatedCard.transform.parent = spawnTarget;
                    break;
                case 3:
                    instantiatedCard = Instantiate(cardRef[2]);
                    instantiatedCard.transform.parent = spawnTarget;
                    break;
                case 4:
                    instantiatedCard = Instantiate(cardRef[3]);
                    instantiatedCard.transform.parent = spawnTarget;
                    break;
                case 5:
                    instantiatedCard = Instantiate(cardRef[4]);
                    instantiatedCard.transform.parent = spawnTarget;
                    break;
                default:
                    break;
            }
        }
    }


    public void spawnCardTemp()
    {
        for (int i = 0; i < spawnData.Length; i++)
        {
            GameObject instantiatedCard;
            instantiatedCard = Instantiate(cardTemp);
            instantiatedCard.transform.parent = spawnTarget;
        }
    }

}

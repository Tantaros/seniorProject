using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecount : MonoBehaviour
{
    public Text TimeCount;
    public Canvas overlay;
    public Text gameOver;
    public float timer;
    public float timer2;
    
    float delay;
    

    public GameObject obj;
    private HandData hp;

    
    // Start is called before the first frame update
    void Start()
    {
        hp = gameObject.GetComponent<HandData>();
        delay = 3;
        timer = 60;
        SetText();
        gameOver.text = "";
        overlay.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {


        if (timer <= 0 )
        {
            timer = 0;
            SetText();
            overlay.gameObject.SetActive(true);
            gameOver.text = "GAME OVER";
        }
        else if (hp.isWin == true)
        {

            timer2 = timer;
            SetText2();

        }
        else
        {
            
            SetText();

        }
        timer -= Time.deltaTime;

    }

    void SetText()
    {
        if(timer <= 9.5)
        {
            TimeCount.text = "00:0" + timer.ToString("f0");
        }
        else if (timer >= 59)
        {
            TimeCount.text = "01:00";
        }
        else
        {
            TimeCount.text = "00:" + timer.ToString("f0");
        }
    }

    void SetText2()
    {
        if (timer <= 9.5)
        {
            TimeCount.text = "00:0" + timer2.ToString("f0");
        }
        else if (timer >= 59)
        {
            TimeCount.text = "01:00";
        }
        else
        {
            TimeCount.text = "00:" + timer2.ToString("f0");
        }
    }

}

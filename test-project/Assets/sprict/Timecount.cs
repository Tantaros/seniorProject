using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecount : MonoBehaviour
{
    public Text TimeCount;
    public Canvas overlay;
    public Text gameOver;
    float timer;
    float delay;
    public Image HPP;

    private float start = 100;
    private float health_p;

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
        timer -= Time.deltaTime;
        DamageBoss();
        if (timer <= 0)
        {
            timer = 0;
            SetText();
            health_p = start;
            overlay.gameObject.SetActive(true);
            gameOver.text = "GAME OVER";
        }
        else
        {
            SetText();

        }
        
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
    public void DamageBoss()
    {
        if ((hp.HPE / start) <= 1 && (timer % 5 <= 2))
        {
            float mm = 5f;

            hp.HPP -= mm;
            HPP.fillAmount = hp.HPP / start;
        }
        else if ((hp.HPE / start) < 0.5 && (timer % 5 <= 3.6))
        {
            float mm = 15f;

            hp.HPP -= mm;
            HPP.fillAmount = hp.HPP / start;
        }
        if (hp.HPP <= 0)
        {
            hp.isWin = false;
        }
        

    }
}

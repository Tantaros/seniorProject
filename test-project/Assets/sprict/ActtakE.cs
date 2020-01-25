using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActtakE : MonoBehaviour
{
    public Image HPP;
    private bool isDead = true;
    private bool triggered = true;

    private float start = 100;
    private float health_p;
    float timer;
    int count = 0;
    int one = 1;

    public GameObject obj;
    private HandData handData;

    // Start is called before the first frame update
    void Start()
    {
        handData = gameObject.GetComponent<HandData>();
        timer = 60;
        health_p = start;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if((timer < 55 && triggered) && one == 1 && count ==0)
        {
            DamageBoss();
            triggered = false;
            one = 0;
            count++;
        }
        if (timer > 45 && timer < 47 && !triggered && one == 0)
        {
            DamageBoss();
            one = 1;
            count++;
        }
        if(timer>39 && timer <=40 && !triggered )
        {
            DamageBoss();
            triggered = true;
        }
        

    }
    public void DamageBoss()
    {
        if (handData.HPE <= 50 && one == 1)
        {
            float mm = (float)(50);

            health_p -= mm;
            HPP.fillAmount = health_p / start;

        }
        else
        {
            float mm = (float)(5 * 0.4 * 2);

            health_p -= mm;
            HPP.fillAmount = health_p / start;
        }

            //hp.HPP = health_p;

           
        
        /*if (health_p <= 0)
        {
            hp.isWin = false;
        }*/


    }
}

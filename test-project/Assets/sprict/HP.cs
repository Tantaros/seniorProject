using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    // Start is called before the first frame update
    public Image HPE;
    public Canvas overlay;
    public Text gameOver;
    public Image Emeny;
    public Image eff;
   

    private float start = 100;

   
    float ss;
    float delay;

    public bool isDead = false;

  

    [Tooltip("get score")]
    public GameObject score;
    private HandData check;

    

    void Start()
    {
        check = score.GetComponent<HandData>();
        
        check.HPP = start;
        check.HPE = start;
        eff.enabled = false;
        delay = 0.6f;
    }

    void Update()
    {
        if(check.isWin == true)
        {
            
            delay -= Time.deltaTime;
            if (delay < 0.5f)
            {
                Emeny.enabled = false;
                eff.enabled = true;
            }
            if (delay <= 0.3f)
            {
                eff.enabled = false;
            }
            if(delay <= 0)
            {
                overlay.gameObject.SetActive(true);
                gameOver.text = "VICTORY";
            }
        }
    }

    public void TakeDamage()
    {
        float amount = (float)check.score/100 * 20 ;

        check.HPE -= amount;

        HPE.fillAmount = check.HPE / start;

        if (check.HPE <= 0 && !isDead)
        {
            check.isWin = true;
        }
        else
        {
            check.isWin = false;
        }
    }
    
    



}

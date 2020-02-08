using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnRe;
    public Button btnRe2;
    public Button btnRe3;
    void Start()
    {
        btnRe.onClick.AddListener(delegate () {
            SceneManager.LoadScene("battle-001"); 
        });
        btnRe2.onClick.AddListener(delegate () {
            SceneManager.LoadScene("battle-001"); 
        });
        btnRe3.onClick.AddListener(delegate () {
            SceneManager.LoadScene("battle-001"); 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

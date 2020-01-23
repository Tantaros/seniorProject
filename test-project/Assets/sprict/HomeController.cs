using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnquest;

    void Start()
    {
        btnquest.onClick.AddListener(delegate () {
            SceneManager.LoadScene("map-001"); // คลิกแล้วเปลี่ยนไปหน้า about
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

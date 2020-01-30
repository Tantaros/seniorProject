using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Map001Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnHome;
    public Button quest001;
    void Start()
    {
        btnHome.onClick.AddListener(delegate () {
            SceneManager.LoadScene("home"); // คลิกแล้วเปลี่ยนไปหน้า home
        });
        quest001.onClick.AddListener(delegate () {
            SceneManager.LoadScene("submap-001"); // คลิกแล้วเปลี่ยนไปหน้า home
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

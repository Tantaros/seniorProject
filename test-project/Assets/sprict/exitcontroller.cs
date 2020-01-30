using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class exitcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public Button q1;
    public Button q2;
    public Button q3;

    void Start()
    {
        q1.onClick.AddListener(delegate () {
            SceneManager.LoadScene("submap-001"); // คลิกแล้วเปลี่ยนไปหน้า home
        });
        q2.onClick.AddListener(delegate () {
            SceneManager.LoadScene("submap-001"); // คลิกแล้วเปลี่ยนไปหน้า home
        });
        q3.onClick.AddListener(delegate () {
            SceneManager.LoadScene("submap-001"); // คลิกแล้วเปลี่ยนไปหน้า home
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

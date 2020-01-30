using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class submap001Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Button quest001;
    public Button map;

    void Start()
    {
        map.onClick.AddListener(delegate () {
            SceneManager.LoadScene("map-001"); // คลิกแล้วเปลี่ยนไปหน้า about
        });
        quest001.onClick.AddListener(delegate () {
            SceneManager.LoadScene("battle-001"); // คลิกแล้วเปลี่ยนไปหน้า about
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

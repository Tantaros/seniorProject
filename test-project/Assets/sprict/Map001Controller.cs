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
    public Button quest002;
    public Button quest003;
    public Button quest004;
    public Button quest005;
    public Canvas submap001;
    void Start()
    {
        btnHome.onClick.AddListener(delegate () {
            SceneManager.LoadScene("home"); // คลิกแล้วเปลี่ยนไปหน้า home
        });
        quest001.onClick.AddListener(delegate () {
            submap001.gameObject.SetActive(true);
        });
        quest002.GetComponent<Button>().interactable = false;
        quest003.GetComponent<Button>().interactable = false;
        quest004.GetComponent<Button>().interactable = false;
        quest005.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

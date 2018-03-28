using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logoutButton : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameObject btnObj = GameObject.Find("logoutButton");
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            Application.Quit();
        });
    }
	
    // Update is called once per frame
    void Update () {
        //pass
    }
}

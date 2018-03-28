using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuButton : MonoBehaviour {
    private bool isShow = false;

	// Use this for initialization
	void Start () {
        GameObject btnObj = GameObject.Find("menuButton");
        Button btn = btnObj.GetComponent<Button>();

        GameObject menu = GameObject.Find("Canvas/menuPanel");
        menu.SetActive(isShow);

        btn.onClick.AddListener(delegate
        {
            isShow = !isShow;
            menu.SetActive(isShow);
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

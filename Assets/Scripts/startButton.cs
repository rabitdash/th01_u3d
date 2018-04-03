using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour {

    // Use this for initialization
    void Start() {
        GameObject btnObj = GameObject.Find("startButton");
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            this.NextScene(btnObj);
        });
    }

    // Update is called once per frame

    void NextScene(GameObject scene)
    {
        SceneManager.LoadScene("run"); //切换到名为run的场景
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    //负责UI事件
    public static UIController _instance;

    #region 按钮定义,须由外部赋值

    public Button confirmButton;
    public Button cancelButton;
    public Button logoutButton;
    public Button startButton;

    private bool isConfirm;
    private bool isCancel;

    #endregion

    // Use this for initialization
    void Awake()
    {
        _instance = this;

        #region 按钮事件监听
        confirmButton.onClick.AddListener(delegate
        {
            Debug.Log("dealButtonClicked!");
        });

        #endregion
    }
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

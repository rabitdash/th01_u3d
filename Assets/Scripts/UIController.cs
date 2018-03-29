using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour {
    // 获取UI控件事件并发送消息
    private Button dealButton; //出牌按钮
    private Button dropButton; //弃牌按钮
    private Button logoutButton; //退出按钮
    private Button menuButton; //菜单按钮
    private Button startButton; //开始游戏按钮

    private GameObject menuPanel;
    private bool isMenuShow = false; //显示菜单
    private Text text; //测试用文本框
    private GameObject canvas;     //画布



    // Use this for initialization
    private void Awake()
    {
        #region 按钮定义
        dealButton = GameObject.Find("Canvas/dealButton").GetComponent<Button>();//出牌按钮
        dropButton = GameObject.Find("Canvas/dropButton").GetComponent<Button>();//弃牌按钮
        logoutButton = GameObject.Find("Canvas/menuPanel/logoutButton").GetComponent<Button>();//退出按钮
        menuButton = GameObject.Find("Canvas/menuButton").GetComponent<Button>();//菜单按钮
        startButton = GameObject.Find("Canvas/startButton").GetComponent<Button>();//
        #endregion
        
        menuPanel = GameObject.Find("Canvas/menuPanel"); //菜单
        menuPanel.SetActive(isMenuShow); //默认隐藏
        text = GameObject.Find("Canvas/testText").GetComponent<Text>();//测试用文本

        #region 按钮监听事件函数
        dealButton.onClick.AddListener(delegate
        {
            Debug.Log("dealButton");

        });
        dropButton.onClick.AddListener(delegate
        {
            Debug.Log("dropButton");
        });
        logoutButton.onClick.AddListener(delegate
        {
            Debug.Log("logoutButton");
            Application.Quit();
        });
        menuButton.onClick.AddListener(delegate
        {
            Debug.Log("menuButton");
            isMenuShow = !isMenuShow;
            menuPanel.SetActive(isMenuShow);
        });

        #endregion
    }
    void Start() {
        
    }

    // Update is called once per frame
    void Update () {
        
	}

}
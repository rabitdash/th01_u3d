using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    // 获取UI控件的各种事件并负责绘制
    private Button dealButton; //出牌按钮
    private Button dropButton; //弃牌按钮
    private Button logoutButton; //退出按钮
    private Button menuButton; //菜单按钮

    private GameObject menuPanel;
    private bool isMenuShow = false; //显示菜单
    private Text text; //测试用文本框
    private GameObject canvas;     //画布

    // 声明委托  
    public delegate void EventHandler();
    // 创建委托  
    public static EventHandler Handler;

    // Use this for initialization
    void Start() {
        #region buttonsDefinition
        dealButton = GameObject.Find("Canvas/dealButton").GetComponent<Button>();//出牌按钮
        dropButton = GameObject.Find("Canvas/dropButton").GetComponent<Button>();//弃牌按钮
        logoutButton = GameObject.Find("Canvas/menuPanel/logoutButton").GetComponent<Button>();//退出按钮
        menuButton = GameObject.Find("Canvas/menuButton").GetComponent<Button>();//菜单按钮
        #endregion

        menuPanel = GameObject.Find("Canvas/menuPanel"); //菜单
        menuPanel.SetActive(isMenuShow); //默认隐藏
        text = GameObject.Find("Canvas/testText").GetComponent<Text>();//测试用文本
        //测试

        #region addButtonListener
        dealButton.onClick.AddListener(delegate
        {
            //Debug.Log("dealButton clicked!");
            text.text = "点击出牌按钮";
            //TODO 
            //传递消息给BattleController
            BattleController.message = "点击出牌按钮";
 

        });

        dropButton.onClick.AddListener(delegate
        {
            //Debug.Log("dropButton clicked!");
            text.text = "点击弃牌按钮";
            //TODO 
            //传递消息给BattleController
            BattleController.message = "点击弃牌按钮";

        });
        logoutButton.onClick.AddListener(delegate
        {
            //Debug.Log("dropButton clicked!");
            text.text = "点击退出按钮";
            BattleController.message = "点击退出按钮";
            Application.Quit();

        });
        menuButton.onClick.AddListener(delegate
        {
            //Debug.Log("dropButton clicked!");
            text.text = "点击菜单按钮";
            //传递消息给BattleController
            BattleController.message = "点击菜单按钮";
            isMenuShow = !isMenuShow;
            menuPanel.SetActive(isMenuShow);
        });
        #endregion
    }

    // Update is called once per frame
    void Update () {
        //获取委托并执行
        while(Handler != null)
        {
            Handler();//执行请求函数
            Handler = null; //清空消息队列
        }
	}

    
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    //战斗逻辑部分
    //变量定义
    //public static string message = null; //UIController从外部将消息写入message
    //public setPlayerTurn(int playerNum)
    const int nplayers = 4;//玩家数量
    private Player Player0 = new Player(0);
    private Player Player1 = new Player(1);
    private Player Player2 = new Player(2);
    private Player Player3 = new Player(3);

    public void InitPlayers()
    {
        Player0 = new Player(0);
        Player1 = new Player(1);
        Player2 = new Player(2);
        Player3 = new Player(3);
    }

    void Awake()
    {

    }

    void Start()
    {
        InitPlayers();
        test();
    }

    void test()
    {
        Player0.AddCard();
        Player1.AddCard();
        Player0.AddCard();
        Player0.AddCard();
    }
    // Update is called once per frame
    void Update()
    {
        //while (message != null)
        {
        //    Debug.Log(message);
        //    message = null;//清空message
        }
    }
    

}

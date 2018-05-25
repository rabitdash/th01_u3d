using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //public SyncListInt heldCards; //个人所持卡牌
    public bool isMyTurn; //是否轮到玩家出牌
    public int ID; //玩家编号
    private static CardManager instance;
    //private static NetSync sync;

    public Player(int id) //初始化构造函数，一开始时调用
    {
        this.ID = id;
        instance = CardManager.Instance;
    }

    /// <summary>
    /// 增加卡牌
    /// </summary>
    /// <param name="cardName"></param>
    public int AddCard(string cardName = null)
    {
        var id = instance.AddCardTo(this.ID, cardName);
        return id;
        //TODO
    }

    public int AddCard(int id = -1)
    {
        id = instance.AddCardTo(this.ID, id);//如果无法加卡返回-1
        return id;
    }
    /// <summary>
    /// 将卡牌移入弃牌堆
    /// </summary>
    public int DropCard(string cardName = null)
    {
        var id = instance.DropCardFrom(this.ID, cardName);
        return id;
        //TODO
    }

    public int DropCard(int id = -1)
    {
        id = instance.DropCardFrom(this.ID, id);//如果无法弃卡返回-1
        return id;
    }
}

public class BattleController : MonoBehaviour
{
    //战斗逻辑部分
    //变量定义
    //public static string message = null; //UIController从外部将消息写入message
    //public setPlayerTurn(int playerNum)
    const int nplayers = 4;//玩家数量
    #region
    public static Player Player0;
    public static Player Player1; 
    #endregion
    public void InitPlayers() //初始化Player
    {
        Player0 = new Player(0);
        Player1 = new Player(1);
    }

    void Awake()
    {
        InitPlayers();
    }

    void Start()
    {

        test();
    }

    void test()
    {
        
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

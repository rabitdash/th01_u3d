using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Player
{
    public List<string> heldCards; //个人所持卡牌
    public bool isMyTurn; //是否轮到玩家出牌
    public int ID; //玩家编号
    private static CardManager instance;

    public Player(int id) //初始化构造函数，一开始时调用
    {
        this.ID = id;
        instance = CardManager.Instance;
}

    void Awake()
    {
        
    }

    void Start()
    {

    }
    /// <summary>
    /// 增加卡牌
    /// </summary>
    /// <param name="cardName"></param>
    public void AddCard(string cardName = null)
    {
        instance.AddCardTo(this.ID, cardName);
        //TODO
    }
    /// <summary>
    /// 将卡牌移入弃牌堆
    /// </summary>
    public void DropCard(string cardName = null)
    {
        instance.DropCardFrom(this.ID, cardName);
        //TODO
    }
//
//    public void GiveCard(Player toPlayer, string cardName = null)
//    {
//        instance.GiveCardTo(this.ID, toPlayer.ID, cardName);
//    }
}
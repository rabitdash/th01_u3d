﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public List<string> heldCards; //个人所持卡牌
    public bool isMyTurn; //是否轮到玩家出牌
    public bool isTimeUp; //玩家是否超时
    public int myNum; //玩家编号

    public Player(int myNum, List<string> heldCards) //初始化构造函数，一开始时调用
    {
        this.myNum = myNum;
        this.heldCards = heldCards;
    }

    public 
    void Start()
    {

    }
    /// <summary>
    /// 增加一张卡牌
    /// </summary>
    /// <param name="cardName"></param>
    public void AddCard(string cardName)
    {
    }
    /// <summary>
    /// 清空所有卡片
    /// </summary>
    public void DropCards()
    {
    }
}

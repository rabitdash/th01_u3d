﻿using System;
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
    private CardManager instance;

    public Player(int id, List<string> heldCards) //初始化构造函数，一开始时调用
    {
        this.ID = id;
        this.heldCards = heldCards;
    }

    void Awake()
    {
        instance = CardManager._instance;
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
        instance.AddCardTo(ID, cardName);
        //TODO
    }
    /// <summary>
    /// 将卡牌移入弃牌堆
    /// </summary>
    public void DropCard(string cardName = null)
    {
        //TODO
    }

    public void GiveCard(string cardName = null)
    {

    }
}
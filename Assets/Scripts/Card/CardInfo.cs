using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardInfo : IComparable
{
    //负责卡牌非U3D对象信息，实现比较接口
    public string _cardFileName; //卡牌文件名
    public string cardName; //卡牌名
    public int cardID; //卡牌ID，卡牌唯一
    public int playerNum; //这张卡目前是谁持有
    public bool isSelected; //是否被选中
    public bool isCovered = false; //是否被暗置
    private bool isDrop; //是否被弃牌
    private bool isUsed; //是否已发动技能
    private CardTypes cardType; //牌的类型
    private int cardIndex;      //牌在所在类型的索引,比如某些重复卡牌

    enum CardTypes //卡牌类型
    {
        Artifact  = 1, //神器卡
        Character = 2, //人物卡
        Event     = 3, //事件卡

    }

    public CardInfo(string cardFileName) //初始化构造函数
    {
        var splits = cardFileName.Split('_'); //文件名：卡牌名_卡牌类型_卡牌索引.png
        this.isSelected = false;
        this._cardFileName = cardFileName;
        this.cardName = splits[0];//获取卡牌名称
        cardIndex = Convert.ToInt32(splits[2]); //获取卡牌索引

        switch (splits[1])
        {
            case "1":
                cardType = CardTypes.Artifact;
                Debug.Log("CardTypes.Artifact");
                break;
            case "2":
                cardType = CardTypes.Character;
                Debug.Log("CardTypes.Character");
                break;
            case "3":
                cardType = CardTypes.Event;
                Debug.Log("CardTypes.Event");
                break;
            default:
                return;
        }
    }

    int IComparable.CompareTo(object obj) //比较各种卡的效果顺序
    {
        CardInfo other = obj as CardInfo;
        if(other == null)
        {
            throw new Exception("Invalid comparation");
        }
        //当前卡比比较的卡优先，返回1
        //可能出bug
        if((int)cardType < (int)other.cardType)
        {
            return 1;
        }
        if((int)cardType > (int)other.cardType)
        {
            return -1;
        }
        if(cardType == other.cardType)
        {
            return 0;
        }
        throw new NotImplementedException();
    }
}

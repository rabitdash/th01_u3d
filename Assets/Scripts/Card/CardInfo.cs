using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardInfo : IComparable //IComparable
{
    public string cardName; //卡牌图片名
    enum CardTypes
    {
        Artifact  = 1, //神器卡
        Character = 2, //人物卡
        Event     = 3, //事件卡

    }
    private CardTypes cardType; //牌的类型
    private int cardIndex;      //牌在所在类型的索引1-13
    

    public CardInfo(string cardName)
    {
        this.cardName = cardName;
        var splits = cardName.Split('_'); //下有文件命名规则

        switch (splits[1])
        {
            case "1":
                cardType = CardTypes.Artifact;
                cardIndex = int.Parse(splits[2]);
                break;
            case "2":
                cardType = CardTypes.Character;
                cardIndex = int.Parse(splits[2]);
                break;
            case "3":
                cardType = CardTypes.Event;
                cardIndex = int.Parse(splits[2]);
                break;
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

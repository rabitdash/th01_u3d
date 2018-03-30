using System;
using System.Collections;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using UnityEngine;
using SLua;

[CustomLuaClass][Serializable] //可序列化 可被Lua脚本调用
public class CardManager : MonoBehaviour {
    #region 变量定义
    public static CardManager _instance;//单例
    public GameObject cardPrefab; //卡牌预制件
    public GameObject publicCardHeap; //出牌堆位置
    public GameObject publicDropHeap;//弃牌堆位置
    public int nplayer; //参与游戏的玩家数量
    private List<CardInfo> allCardInfos = new List<CardInfo>(); //所有的CardInfo
    private Dictionary<int, List<int>> _PlayerCards = new Dictionary<int, List<int>>(); //key:玩家编号 value:卡牌ID
    private Dictionary<int, GameObject> _cardIdDictionary = new Dictionary<int, GameObject>(); //key:卡牌编号 value:卡牌GameObject对象
    #endregion

    //生成玩家数组
    private void InitAllPlayers()
    {
        for (var i = 0; i < nplayer; i++)
        {

        }
    }
    //生成Card对象数组
    private void InitAllCards()
    {
        var fullPath = "Assets/Resources/Cards/Images/";
        Debug.Log("shit");
        var allCardNames = new List<string>();
        if(Directory.Exists(fullPath))
        {
            var folder = new DirectoryInfo(fullPath);
            foreach (var file in folder.GetFiles("*.png"))
            {
                Debug.Log(file.Name);
                allCardNames.Add(file.Name.Split('.')[0]); //将卡牌文件名加入列表
            }
                
        }

        foreach (var cardFileName in allCardNames)
        {
            allCardInfos.Add(new CardInfo(cardFileName)); //调用CardInfo构造函数，将对象加入列表
        }
           
    }

    //生成卡牌GameObject对象
    private void GenerateCardObjects()
    {
        for (var i = 0; i < 1; i++)
        {
            var card = Instantiate(cardPrefab, publicCardHeap.transform);//复制构造对象
            card.GetComponent<Card>().InitCard(allCardInfos[i], i); //每张卡都有专属ID和CardInfo
            _cardIdDictionary.Add(i, card); //将ID与对应的卡牌GameObject对象存入字典
        }
    }

    //获取某玩家手牌,在判断对方是否有某手牌时会用到
    private List<int> GetPlayerCards(int playerNum) {
        return _PlayerCards[playerNum]; 
    }

    //洗牌
    public void ShuffleCards()
    {

    }

    

    // Use this for initialization
    private void Awake () {
        _instance = this; //单例
        InitAllCards();
        GenerateCardObjects();
	}
	
	// Update is called once per frame
    private void Update () {
		
	}
}

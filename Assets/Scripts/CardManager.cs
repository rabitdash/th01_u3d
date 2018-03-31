using System;
using System.Collections;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using UnityEngine;

[Serializable] //可序列化
public class CardManager : MonoBehaviour {
    #region 变量定义
    public static CardManager _instance;//单例
    public GameObject cardPrefab; //卡牌预制件
    public GameObject publicCardHeap; //出牌堆位置
    public GameObject publicDropHeap;//弃牌堆位置
    public int nplayer; //参与游戏的玩家数量
    private List<CardInfo> allCardInfos = new List<CardInfo>(); //所有的CardInfo
    private List<Transform> allPlayersTransform; //所有Player的位置
    private Dictionary<int, List<int>> _PlayerCards = new Dictionary<int, List<int>>(); //key:玩家编号 value:卡牌ID
    private Dictionary<int, string> _IdOfCardName = new Dictionary<int, string>(); //key:卡牌ID value:卡牌名称
    private Dictionary<int, GameObject> _cardIdDictionary = new Dictionary<int, GameObject>(); //key:卡牌编号 value:卡牌GameObject对象
    #endregion

    //生成玩家数组
    private void InitAllPlayers()
    {
        for (var i = 0; i < nplayer; i++)
        {
            allPlayersTransform[i] = GameObject.Find(String.Format("Canvas/Players/Player{0}", i)).GetComponent<Transform>();//查找所有玩家位置
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

        foreach (var cardFileName in allCardNames)//遍历卡牌文件名数组
        {
            allCardInfos.Add(new CardInfo(cardFileName)); //调用CardInfo构造函数，将CardInfo对象加入列表(1)
        }
           
    }

    //生成卡牌GameObject对象
    private void GenerateCardObjects()
    {
        for (var i = 0; i < allCardInfos.Count; i++)
        {
            var card = Instantiate(cardPrefab, publicCardHeap.transform);//复制构造Card对象
            card.name = string.Format("Card{0}", i);
            card.GetComponent<Card>().InitCard(allCardInfos[i], i); //每张卡都有专属ID和CardInfo，利用(1)中生成的CardInfo对象生成Card对象的属性
            _cardIdDictionary.Add(i, card); //将卡牌ID与对应的卡牌GameObject对象存入字典
        }
    }

    //获取某玩家手牌,在判断对方是否有某手牌时会用到
    private List<int> GetPlayerCards(int playerNum) {
        return _PlayerCards[playerNum]; 
    }

    private bool ifPlayerHaveCards(int playerNum, string cardName)
    {
        return false; //TODO
    }

    //洗牌
    private void ShuffleCards()
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

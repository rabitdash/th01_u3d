using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[Serializable]
public class Card : MonoBehaviour
{
    //是一个Unity中的游戏对象类
    private Image faceImage;        //卡面图片
    //private Image coverImage; 
    public CardInfo cardInfo;  //卡牌信息
    private TextAsset description; //卡牌描述
    private Text textBox; //Debug
    private Transform HeapTransform; //牌堆位置

    private GameObject _self;


    void Awake()
    {

        faceImage = transform.Find("Face").GetComponent<Image>();
        //coverImage = transform.Find("Cover").GetComponent<Image>();

    }

    void Start()
    {
//        ExecuteCardSkill(2);
    }
    void Update()
    {
    }


    public void InitCard(CardInfo cardInfo,int cardId) //初始化卡牌对象数据
    {
        this.cardInfo = cardInfo;
        cardInfo.cardID = cardId;
        InitImage();
        _self = GameObject.Find(String.Format("Card{0}/Face", cardId)); //TODO 修改_self名
        HeapTransform = GameObject.Find(String.Format("Player{0}/cardArea", cardInfo.playerNum)).GetComponent<Transform>();
        //InitDescription();
        //InitCardSkill();

    }

    #region InitCard()所需函数
    private void InitImage() //读取图像
    {
        Debug.Log(cardInfo._cardFileName); //Debug
        var tmp = Resources.Load("Cards/Images/" + cardInfo._cardFileName, typeof(Sprite)) as Sprite; 
        //TODO 读取卡背文件(如果不同类型的卡牌卡背不一样的话s
        if (tmp != null)
        {
            faceImage.sprite = tmp;
        }
        else
        {
            //TODO 错误捕捉
        }


    }

    private void InitDescription()//TODO
    {
        var tmp = Resources.Load("Cards/Descriptions/" + cardInfo._cardFileName, typeof(TextAsset)) as TextAsset;
        if (tmp != null)
        {
            description = tmp;
        }
        else
        {
            //TODO 错误捕捉
        }

        Debug.Log(description.text);
    }

    /*private void InitCardSkill() //初始化卡牌技能,根据卡牌名称读取相应Lua文件
    {
        //        （1）首先要在Lua虚拟机中加载该函数（LuaState.DoFile）
        //
        //        （2）拿到目标函数（LuaState.GetFunction）
        //
        //        （3）执行目标函数（LuaFunction.Call）
        luaState.loaderDelegate = ((string fn) =>
        {

            //获取脚本启动代理
            string file_path = Directory.GetCurrentDirectory() + "/Assets/Resources/Cards/Skills/" + fn;

            Debug.Log("file_path:" + file_path);

            return File.ReadAllBytes(file_path);

        });
        luaState.doFile(String.Format("{0}.lua", cardInfo.cardName));
        //TODO
    }*/
    #endregion
//    public void ExecuteCardSkill(int toPlayerNum) //执行卡牌技能
//    {
//        LuaTable luaCardSkill = luaState.getFunction("CardSkill").call(cardInfo.playerNum,toPlayerNum);
//        
//    }

    IEnumerator Timer() //Debug
    {
        while (true)
        {
            Debug.Log("TimerUp");
            yield return new WaitForSeconds(3);
        }

    }

    #region 鼠标事件函数,直接执行
    //玩家鼠标移到卡牌上
    public void OnMouseEnter()
    {
        if (!DOTween.IsTweening(transform))
        {

            transform.DOMoveY(HeapTransform.position.y, 0.1f);//TODO 现在只是假设Player0的情况
            //transform.DOScale(new Vector3(1f, 1f, 1f), 0.01f);
        }
        Debug.Log("OnMouseEnter");
    }
    
    //玩家鼠标离开卡牌
    public void OnMouseExit() 
    {
        //if (!DOTween.IsTweening(transform))
        {
            transform.DOMoveY(HeapTransform.position.y - 10f, 0.1f); //TODO
            //transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 0.01f);
        }
        Debug.Log("OnMouseExit");
    }
    //玩家鼠标点击卡牌
    public void OnMouseDown()
    {
        this.cardInfo.isSelected = !this.cardInfo.isSelected;//卡牌初始化时默认isSelected=false
        _self.SetActive(!this.cardInfo.isCovered);
        this.cardInfo.isCovered = !this.cardInfo.isCovered;

    }
    #endregion
}


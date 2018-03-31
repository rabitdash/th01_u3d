using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using SLua;
using System.IO;

[Serializable][CustomLuaClass]
public class Card : MonoBehaviour
{
    //是一个Unity中的游戏对象类
    private Image faceImage;        //牌的图片
    public CardInfo cardInfo;  //卡牌信息
    private TextAsset description; //卡牌描述
    private Text textBox; //Debug
    private LuaSvr l;
    private LuaState luaState;//设置Lua状态机对象
    private LuaFunction luaFunction;

    private CanvasRenderer imageRenderer;

    GameObject go;
    private Transform self;


    void Awake()
    {

        self = transform.Find("Face");
        faceImage = self.GetComponent<Image>();
        luaState = new LuaState();

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
        InitCardSkill();
        InitDescription();
    }

    #region InitCard()所需函数
    private void InitImage()
    {
        Debug.Log(cardInfo._cardFileName);
        faceImage.sprite = Resources.Load("Cards/Images/" + cardInfo._cardFileName, typeof(Sprite)) as Sprite;
        
    }

    private void InitDescription()//TODO
    {
        description = Resources.Load("Cards/Descriptions/" + cardInfo._cardFileName, typeof(TextAsset)) as TextAsset;
        Debug.Log(description.text);
    }

    private void InitCardSkill() //初始化卡牌技能,根据卡牌名称读取相应Lua文件
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
    }
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
        var trans = go.transform;
        if (!DOTween.IsTweening(transform))
        {

            transform.DOMoveY(trans.position.y + 100f, 0.01f);
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.01f);
        }
        Debug.Log("OnMouseEnter");
    }
    
    //玩家鼠标离开卡牌
    public void OnMouseExit() 
    {
        var trans = go.transform;
        if (!DOTween.IsTweening(transform))
        {
            transform.DOMoveY(trans.position.y, 0.01f);
            transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 0.01f);
        }
        Debug.Log("OnMouseExit");
    }
    //玩家鼠标点击卡牌
    public void OnMouseDown()
    {
        this.cardInfo.isSelected = !this.cardInfo.isSelected;//卡牌初始化时默认isSelected=false

    }
    #endregion
}


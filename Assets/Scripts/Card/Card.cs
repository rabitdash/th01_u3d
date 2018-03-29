using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    private Image image;        //牌的图片
    //private CardInfo cardInfo = new CardInfo();  //卡牌信息
    private bool isSelected = true;    //是否选中
    GameObject go;
    void Awake()
    {
        image = GetComponent<Image>();
        go = GameObject.Find("Canvas/Player0/HeapPos");


    }
    /// <summary>
    /// 设置选择状态
    /// </summary>
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

}


using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
    {
        private Image image;        //牌的图片
        //private CardInfo cardInfo;  //卡牌信息
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
        public void SetSelectState()
        {
            var trans= go.transform;    

                if (isSelected && !DOTween.IsTweening(transform))
                {

                    transform.DOMoveY(trans.position.y + 100f, 1f);
                    transform.DOScale(new Vector3(2f, 2f, 2f), 0.2f);
                }
                else if(!isSelected && !DOTween.IsTweening(transform))
                {
                    transform.DOMoveY(trans.position.y, 1f);
                    transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f),0.2f);
                }
        isSelected = !isSelected;
    }
    }

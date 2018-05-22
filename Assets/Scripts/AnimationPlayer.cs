using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Tools
{
    public class AnimationPlayer : MonoBehaviour
    {
        //一次性翻面
        public static void CardTurnOver(Transform tr)
        {
            Tweener move1 = tr.DORotate(Vector3.up * 90, 0.5f);
            Tweener move2 = tr.DORotate(Vector3.zero, 0.5f);
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(move1);
            mySequence.AppendCallback(() =>
            {
                tr.rotation = Quaternion.Euler(0, -90, 0);
                tr.Find("Cover").gameObject.SetActive(false);
            });
            mySequence.Append(move2);
        }
    }


}

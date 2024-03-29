﻿using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> アイテムボックスな内でアイテムを選んだ時のログ表示 </summary>
public class ItemLog : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //アイテムの説明を表示(子オブジェクトに設定)
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //表示していたLogを閉じる
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}

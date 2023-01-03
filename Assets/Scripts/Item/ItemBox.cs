using Consts;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemList = new();

    private static ItemBox _instance = default;

    public List<GameObject> ItemList { get => _itemList; set => _itemList = value; }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //テスト用(アイテム削除)
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (_instance.ItemList?.Count > 0)
                DisposeToList(_instance.ItemList[0]);
        }
    }

    //TODO：アイテムを取得した時、リストが上限に達してなければ追加
    public static void AddToList(GameObject item)
    {
        if (_instance.ItemList.Count <= Define.ITEM_LIST_LIMIT)
        {
            _instance.ItemList.Add(item);
            item.SetActive(false);
            Debug.Log($"{item.name} をアイテムボックスに追加しました。");
        }
        else
        {
            Debug.Log("リストが上限に達しているため、アイテムを追加できません。");
        }
    }

    /// <summary>
    /// アイテムを捨て、Listから削除する
    /// </summary>
    public static void DisposeToList(GameObject item)
    {
        _instance.ItemList.Remove(item);
        Debug.Log($"{item.name} をアイテムボックスから削除しました。");
    }

    /// <summary>
    /// 選んだアイテムを使い、Listから削除する
    /// </summary>
    public static void UseItem(GameObject item)
    {
        //TODO：ここでアイテムを使用する関数を実行
        _instance.ItemList.Remove(item);
        Debug.Log($"{item.name} を使用し、アイテムボックスから削除します。");
    }
}

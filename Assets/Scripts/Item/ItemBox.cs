using Consts;
using Item;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemBox : MonoBehaviour
{
    //TODO：アイテムのプレハブをつくり、以下の配列に入れる
    [Tooltip("アイテムの種類")]
    [SerializeField] private GameObject[] _items = new GameObject[3];
    private List<GameObject> _itemList = new();

    [Header("テスト用")]
    [Tooltip("アイテムの有効時間")]
    [SerializeField] private float _validTime = 1f;
    [SerializeField] private UnityEvent _itemEvent;

    private static ItemBox _instance = default;

    public GameObject[] Items => _items;
    public List<GameObject> ItemList { get => _itemList; set => _itemList = value; }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        //テスト用(アイテム削除)
        if (Input.GetKeyDown(KeyCode.R))
        {
            DisposeToList(_itemList[0]);
        }
        //テスト用(アイテム使用)
        if (Input.GetKeyDown(KeyCode.U))
        {
            _itemEvent?.Invoke();
        }
    }

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

    public static void DisposeToList(GameObject item)
    {
        if (_instance.ItemList?.Count > 0)
        {
            _instance.ItemList.Remove(item);
            Debug.Log($"{item.name} をアイテムボックスから削除しました。");
        }
        else
        {
            Debug.LogError("アイテムボックスが空です。");
        }
    }

    /// <summary>
    /// UIでアイテムを選択したときに実行する
    /// </summary>
    /// <param name="item"> アイテムの種類 </param>
    public void ConsumeItem(int item)
    {
        var parent = gameObject.transform.parent.gameObject;
        GameObject consume = _items[item];

        if (_itemList?.Count > 0 && _itemList.Contains(consume))
        {
            //アイテムを使うとき、以下の処理を呼び出す
            switch (item)
            {
                case 0:
                    UseItem.StealthItem(parent);
                    break;
                case 1:
                    UseItem.HealItem(parent);
                    break;
                case 2:
                    UseItem.StatusUpItem(parent, Random.Range(1, 5));
                    break;
            }
            _itemList.Remove(consume);
            Debug.Log($"{consume.name} を使用し、アイテムボックスから消費します。");
        }
        else
        {
            Debug.LogError("指定されたアイテムがありません。");
        }
    }
}

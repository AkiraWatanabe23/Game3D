using Consts;
using Item;
using UnityEngine;
using UnityEngine.Events;

public class ItemBox : MonoBehaviour
{
    [Tooltip("アイテムの種類")]
    [SerializeField] private GameObject[] _items = new GameObject[3];
    [SerializeField] private int[] _itemCount = new int[3];

    [Header("テスト用")]
    //[Tooltip("アイテムの有効時間")]
    //[SerializeField] private float _validTime = 1f;
    [SerializeField] private UnityEvent _itemEvent;

    private GameObject _player = default;
    private static ItemBox _instance = default;

    public GameObject[] Items => _items;
    public int[] ItemCount { get => _itemCount; set => _itemCount = value; }

    private void Awake()
    {
        _player = transform.parent.gameObject;
        _instance = this;
    }

    private void Update()
    {
        //TODO：アイテム使用時、削除時にPause処理が必要
        //テスト用(アイテム使用、削除)
        if (Input.GetKeyDown(KeyCode.I))
        {
            _itemEvent?.Invoke();
        }
    }

    public static void AddToList(int item)
    {
        var sum = _instance.ItemCount[0] + _instance.ItemCount[1] + _instance.ItemCount[2];

        if (sum <= Define.ITEM_LIST_LIMIT)
        {
            _instance.ItemCount[item]++;
        }
        else
        {
            Debug.Log("リストが上限に達しているため、アイテムを追加できません。");
        }
    }

    public void DisposeToList(int item)
    {
        if (_itemCount[item] > 0)
        {
            _itemCount[item]--;
            Debug.Log($"指定されたアイテムをリストから削除しました。");
        }
        else
        {
            Debug.LogError("指定されたアイテムは既にリストにありません。");
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

        if (_itemCount[item] > 0)
        {
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
            _itemCount[item]--;
            Debug.Log($"{consume.name} を使用し、アイテムボックスから消費します。");
        }
        else
        {
            Debug.LogError("指定されたアイテムがありません。");
        }
    }
}

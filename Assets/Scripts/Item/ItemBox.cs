using Consts;
using Item;
using UnityEngine;
using UnityEngine.Events;

public class ItemBox : MonoBehaviour
{
    [Tooltip("アイテムリストを開くキー")]
    [SerializeField] private KeyCode _itemKey;
    [Tooltip("アイテムの種類")]
    [SerializeField] private GameObject[] _items = new GameObject[3];
    [SerializeField] private int[] _itemCount = new int[3];

    [Header("テスト用")]
    [Tooltip("アイテムの有効時間")]
    [SerializeField] private float _validTime = 1f;
    [SerializeField] private UnityEvent _itemEvent = default;

    private int _statusNum = 0;
    private float _upValue = 0;
    private float _usingTimer = 0f;
    private bool _isUsing = false;
    private GameObject _player = default;

    private static ItemBox _instance = default;

    public GameObject[] Items => _items;
    public int[] ItemCount { get => _itemCount; set => _itemCount = value; }
    public int StatusNum { get => _statusNum; set => _statusNum = value; }
    public float UpValue { get => _upValue; set => _upValue = value; }
    public bool IsUsing { get => _isUsing; set => _isUsing = value; }

    private void Awake()
    {
        _player = transform.parent.gameObject;
        _instance = this;
    }

    private void Update()
    {
        //アイテムの使用時間制限(一定時間経ったら解除)
        if (_isUsing)
        {
            _usingTimer += Time.deltaTime;
            if (_usingTimer >= _validTime)
            {
                _usingTimer = 0f;
                _isUsing = false;
                CancelItem();
            }
        }

        //アイテム使用、削除
        if (Input.GetKeyDown(_itemKey))
            _itemEvent?.Invoke();
    }

    public static void AddToList(int item)
    {
        var sum = _instance.ItemCount[0] + _instance.ItemCount[1] + _instance.ItemCount[2];

        if (sum <= Define.ITEM_LIST_LIMIT)
            _instance.ItemCount[item]++;
        else
            Debug.Log("リストが上限に達しているため、アイテムを追加できません。");
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

    /// <summary> UIでアイテムを選択したときに実行する </summary>
    /// <param name="item"> アイテムの種類 </param>
    public void ConsumeItem(int item)
    {
        GameObject consume = _items[item];

        if (_itemCount[item] > 0)
        {
            switch (item)
            {
                case 0:
                    UseItem.StealthItem(_player);
                    break;
                case 1:
                    UseItem.HealItem(_player);
                    break;
                case 2:
                    UseItem.StatusUpItem(_player, Random.Range(1, 5));
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

    private void CancelItem()
    {
        if (_player.CompareTag(Define.STEALTH_TAG))
        {
            //ステルスアイテムの解除
            _player.tag = Define.PLAYER_TAG;

            float alpha = 1f;
            Color color = _player.GetComponent<MeshRenderer>().material.color;

            color.a = alpha;
            _player.GetComponent<MeshRenderer>().material.color = color;
            Debug.Log("ステルス解除");
        }
        else
        {
            //ステータス向上アイテムの解除(上昇前のステータスに戻す)
            var value = _player.GetComponent<PlayerController>().Movements;
            switch (_statusNum)
            {
                case 1:
                case 2:
                    value.MoveSpeed -= _upValue;
                    value.JumpPower -= _upValue;
                    break;
            }
            Debug.Log("ステータス向上解除");
        }
    }
}

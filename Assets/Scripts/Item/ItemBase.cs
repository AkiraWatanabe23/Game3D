using Consts;
using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// アイテムの基底クラス
/// </summary>
public class ItemBase : MonoBehaviour
{
    [Tooltip("効果の有効時間")]
    [SerializeField] private float _validTime = 0f;
    [Tooltip("アイテムの種類")]
    [SerializeField] private ItemType _type = ItemType.DEFAULT;

    [HideInInspector] private StealthItem _stealth = default;
    [HideInInspector] private HealItem _heal = default;
    [HideInInspector] private StatusUpItem _status = default;

    public ItemType Type => _type;
    public StealthItem Stealth => _stealth;
    public HealItem Heal => _heal;
    public StatusUpItem Status => _status;

    private void UseItem(ItemType item)
    {
        //アイテムを使うとき、この関数を呼び出す(テスト)
        switch (item)
        {
            case ItemType.STEALTH:
                _stealth.UseItem(gameObject);
                break;
            case ItemType.HEAL:
                _heal.UseItem(gameObject);
                break;
            case ItemType.STATUSUP:
                _status.UseItem(gameObject);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            ItemBox.AddToList(gameObject);
        }
    }
}

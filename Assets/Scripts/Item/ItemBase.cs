using Consts;
using UnityEngine;

/// <summary>
/// アイテムの基底クラス(入手したらボックスに追加)
/// 使用等の処理はアイテムボックスに記述
/// </summary>
public class ItemBase : MonoBehaviour
{
    [Tooltip("このアイテムの種類")]
    [SerializeField] private ItemType _type = ItemType.DEFAULT;
    [Tooltip("効果の有効時間")]
    [SerializeField] private float _validTime = 1f;

    public ItemType Type => _type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            ItemBox.AddToList(gameObject);
        }
    }
}

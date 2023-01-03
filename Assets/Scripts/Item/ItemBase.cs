using Consts;
using UnityEngine;

/// <summary>
/// アイテムの基底クラス
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [Tooltip("効果の有効時間")]
    [SerializeField] private float _validTime = 0f;

    public float ValidTime => _validTime;

    /// <summary>
    /// アイテムを使用するときに実行する関数
    /// </summary>
    protected abstract void UseItem(GameObject go);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            ItemBox.AddToList(gameObject);
        }
    }
}

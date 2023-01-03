using Consts;
using UnityEngine;

/// <summary>
/// Playerをステルス状態にして敵に見つからなくするアイテム
/// </summary>
[System.Serializable]
public class StealthItem
{
    [SerializeField] private float _stealthTime = 1f;

    public void UseItem(GameObject go)
    {
        //↓Playerをステルス状態にする
        go.tag = Define.STEALTH_TAG;
        //↓視覚的なステルス状態(透明度を半分まで落とす)
        float alpha = 1f;
        Color color = go.GetComponent<MeshRenderer>().material.color;
        alpha /= 2f;

        color.a = alpha;
        go.GetComponent<MeshRenderer>().material.color = color;
    }
}

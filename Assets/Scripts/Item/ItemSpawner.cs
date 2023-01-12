using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> ランダムなアイテムを一定時間ごとにスポーンする </summary>
public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _items = new GameObject[3];
    [SerializeField] private List<Transform> _spawnPos = new();
    [SerializeField] private float _spawnTime = 1f;

    private void Start()
    {
        //ItemSpawn()を_spawnTime(s)後に呼び出し、その後_spawnTime(s)間隔で実行する
        InvokeRepeating(nameof(ItemSpawn), _spawnTime, _spawnTime);
    }

    private void ItemSpawn()
    {
        //TODO：同じ場所にアイテムがスポーンされるのを防ぐ
        foreach (var spawn in _spawnPos)
        {
            var go = Instantiate(_items[Random.Range(0, _items.Length)]);
            go.transform.position = spawn.position;
        }
    }
}

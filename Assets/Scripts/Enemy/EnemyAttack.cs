using UnityEngine;

[System.Serializable]
public class EnemyAttack
{
    [SerializeField] private int _attackValue = 10;
    [SerializeField] private float _attackInterval = 5f;
    [SerializeField] private LayerMask _layer = default;

    private float _attackCount = 0f;
    private float _rayDis = 10f;
    private Transform _trans = default;

    public void Init(Transform trans)
    {
        _trans = trans;
    }

    public void Update()
    {
        _attackCount += Time.deltaTime;
        if (_attackCount >= _attackInterval)
        {
            if (Physics.Raycast(_trans.position, _trans.forward, out RaycastHit hit, _rayDis, _layer))
            {
                //TODO：攻撃処理(Animation再生、SE流す、Playerにダメージ)
                hit.collider.gameObject.GetComponent<PlayerController>().Health.Damage(_attackValue);
                Debug.Log($"Playerに {_attackValue}ダメージ");
            }
            _attackCount = 0f;
        }
    }
}

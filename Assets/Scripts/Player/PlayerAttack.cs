using UnityEngine;

[System.Serializable]
public class PlayerAttack
{
    [Header("攻撃系Status")]
    [SerializeField] private int _attackValue = 5;
    [SerializeField] private LayerMask _layer = default;
    [SerializeField] private Transform _muzzle = default;

    public int AttackValue => _attackValue;

    public void Init()
    {

    }

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = default;
        GameObject point = null;

        //マウスの指す先にRayをとばし、Enemyがいるか判定
        if (Physics.Raycast(ray, out hit, 10, _layer))
        {
            UIManager.IsHit = true;
            point = hit.collider.gameObject;
            Debug.Log($"Hit {point.name}");
        }
        else
        {
            UIManager.IsHit = false;
        }

        //TODO：攻撃処理(銃の動き)
        if (Input.GetButtonDown("Fire1"))
        {
            //Rayが当たっているのがEnemyかどうかを判定
            if (point.TryGetComponent<EnemyController>(out var enemy))
            {
                //Enemyだったら、ダメージを与える
                enemy.GetComponent<EnemyController>().Damage(_attackValue);
            }
        }
    }
}

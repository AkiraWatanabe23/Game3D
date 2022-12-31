using Consts;
using UnityEngine;

public class EnemyController : EnemyBase
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        //destination...行き先(NavMeshの進行方向の決定)
        Agent.SetDestination(_target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO：指定の箇所を行ったり来たりするようにする

        if (other.CompareTag(Define.PLAYER_TAG))
        {
            //TODO：Playerに追いついたときになにか処理をする
        }
    }
}

using Consts;
using UnityEngine;

public class EnemyController : EnemyBase
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        //destination...�s����(NavMesh�̐i�s�����̌���)
        Agent.SetDestination(_target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO�F�w��̉ӏ����s�����藈���肷��悤�ɂ���

        if (other.CompareTag(Define.PLAYER_TAG))
        {
            //TODO�FPlayer�ɒǂ������Ƃ��ɂȂɂ�����������
        }
    }
}

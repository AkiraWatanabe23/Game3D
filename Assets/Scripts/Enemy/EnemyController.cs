using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IPause
{
    [SerializeField] private EnemyMove _movement = default;
    [SerializeField] private EnemyAttack _attack = default;

    private NavMeshAgent _agent = default;

    public EnemyMove Movement => _movement;
    public EnemyAttack Attack => _attack;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _movement.Init(_agent, transform);
        _attack.Init();
    }

    [Obsolete]
    private void Update()
    {
        if (GameManager.IsPause)
            Pause();
        else
            Resume();

        _movement.Update();
        _attack.Update();
    }

    private void OnTriggerStay(Collider other)
    {
        _movement.OnTriggerStay(other);
    }

    [Obsolete]
    public void Pause()
    {
        _agent.Stop();
    }

    [Obsolete]
    public void Resume()
    {
        _agent.Resume();
    }
}
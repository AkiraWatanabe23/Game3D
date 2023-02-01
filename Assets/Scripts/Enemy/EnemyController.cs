using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour, IPause
{
    [SerializeField] private EnemyMove _movement = default;
    [SerializeField] private EnemyAttack _attack = default;

    private NavMeshAgent _agent = default;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _movement.Init(_agent, transform);
        _attack.Init(transform);
    }

    [Obsolete]
    private void Update()
    {
        if (GameManager.IsPause)
        {
            Pause();
        }
        else
        {
            Resume();

            _movement.Update();
            _attack.Update();
        }
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
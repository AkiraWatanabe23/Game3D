using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private List<Transform> _movePos = new();

    private NavMeshAgent _agent = default;
    private EnemyState _state = EnemyState.DEFAULT;

    public List<Transform> MovePos => _movePos;
    public NavMeshAgent Agent => _agent;
    public EnemyState State { get => _state; set => _state = value; }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public enum EnemyState
    {
        DEFAULT,
        /// <summary> 通常の移動状態 </summary>
        MOVE,
        /// <summary> Player追跡中 </summary>
        CHASE,
    }
}

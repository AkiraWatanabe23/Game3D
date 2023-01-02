using Consts;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    //[SerializeField] private Transform _target;
    [SerializeField] private Transform[] _movePos = new Transform[2];

    private NavMeshAgent _agent = default;
    private EnemyState _state = EnemyState.DEFAULT;
    private int _currentMoveIndex = 0;
    private float _moveSpeed = 0f;

    public Transform[] MovePos => _movePos;
    public NavMeshAgent Agent => _agent;
    public EnemyState State { get => _state; set => _state = value; }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _state = EnemyState.MOVE;
        _currentMoveIndex = 0;
        _moveSpeed = _agent.speed;

        if (_agent != null) Debug.Log("aruno");
        else Debug.Log("naino");
    }

    private void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            SwitchTarget();
        }
    }

    //TODO：指定の箇所を行ったり来たりするようにする
    private void SwitchTarget()
    {
        _agent.speed = _moveSpeed;
        _currentMoveIndex++;
        _agent.SetDestination
            (_movePos[_currentMoveIndex % _movePos.Length].position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Define.PLAYER_TAG))
        {
            //TODO：Playerに追いついたときになにか処理をする
        }
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

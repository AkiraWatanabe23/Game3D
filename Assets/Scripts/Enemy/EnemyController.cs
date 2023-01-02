using Consts;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform[] _movePos = new Transform[2];
    [Tooltip("視界の範囲(正面から)")]
    [Range(0f, 180f)]
    [SerializeField] private float _searchAngle = 0f;

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

        _agent.SetDestination(_movePos[0].position);
    }

    private void Update()
    {
        //指定の箇所を行ったり来たりするようにする
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            SwitchTarget();
        }

        //もしPlayerを追跡している状態なら
        if (_state == EnemyState.CHASE)
        {
            //TODO：Playerの位置を常にEnemyの追跡対象にする
        }
    }

    /// <summary>
    /// 追跡先を次の位置に切り替える
    /// </summary>
    private void SwitchTarget()
    {
        _agent.speed = _moveSpeed;
        _currentMoveIndex++;
        _agent.SetDestination
            (_movePos[_currentMoveIndex % _movePos.Length].position);
    }

    private void ChasePlayer(GameObject go)
    {
        var posDiff = go.transform.position - gameObject.transform.position;
        var angle = Vector3.Angle(transform.forward, posDiff);

        if (angle <= _searchAngle)
        {
            Debug.Log("Find Player");
            _state = EnemyState.CHASE;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Define.PLAYER_TAG))
        {
            //TODO：Playerを発見した(視界に入った)ときになにか処理をする
            ChasePlayer(other.gameObject);
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

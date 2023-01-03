using Consts;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour, IPause
{
    [SerializeField] private Transform[] _movePos = new Transform[2];
    [Tooltip("視界の範囲")]
    [Range(0f, 180f)]
    [SerializeField] private float _searchAngle = 0f;
    [Tooltip("何秒経ったらPlayerの追跡をやめるか")]
    [SerializeField] private float _stopChaseTime = 1f;

    [Header("テスト用")]
    [SerializeField] private bool _isPause = false;

    private GameObject _player = default;
    private NavMeshAgent _agent = default;
    private EnemyState _state = EnemyState.DEFAULT;
    private int _currentMoveIndex = 0;
    private float _moveSpeed = 0f;
    private float _chaseTime = 0f;

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

    [System.Obsolete]
    private void Update()
    {
        if (_isPause)
        {
            Pause();
        }
        else
        {
            Resume();
        }

        //指定の箇所を行ったり来たりするようにする
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            SwitchTarget();
        }

        //Playerを追跡する
        if (_state == EnemyState.CHASE)
        {
            _chaseTime += Time.deltaTime;
            _agent.SetDestination(_player.transform.position);

            //一定時間経ったら追跡をやめて、元の場所に戻る
            if (_chaseTime >= _stopChaseTime)
            {
                _state = EnemyState.MOVE;
                _agent.SetDestination
                    (_movePos[_currentMoveIndex % _movePos.Length].position);
            }
        }
    }

    /// <summary>
    /// 進行先を次の位置に切り替える
    /// </summary>
    private void SwitchTarget()
    {
        _agent.speed = _moveSpeed;
        _currentMoveIndex++;
        _agent.SetDestination
            (_movePos[_currentMoveIndex % _movePos.Length].position);
    }

    /// <summary>
    /// Playerが視界の中に入っているか
    /// </summary>
    /// <param name="go"> Playerのオブジェクト </param>
    private void ChasePlayer(GameObject go)
    {
        var playerVec = go.transform.position - gameObject.transform.position;
        var angle = Vector3.Angle(transform.forward, playerVec);

        if (angle <= _searchAngle)
        {
            Debug.Log("Find Player");
            _state = EnemyState.CHASE;
            _player = go;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Define.PLAYER_TAG))
        {
            //Playerを発見した(視界に入った)ときに追跡するようにする
            ChasePlayer(other.gameObject);
        }
    }

    [System.Obsolete]
    public void Pause()
    {
        //TODO：一時停止処理の記述
        //移動、探索を停止する
        _agent.Stop();
    }

    [System.Obsolete]
    public void Resume()
    {
        //TODO：処理再開の記述
        _agent.Resume();
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

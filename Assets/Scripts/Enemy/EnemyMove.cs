using Consts;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove
{
    [SerializeField] private Transform[] _movePos = new Transform[2];
    [Tooltip("視界の範囲(*2)")]
    [Range(0f, 180f)]
    [SerializeField] private float _searchAngle = 0f;
    [Tooltip("何秒経ったらPlayerの追跡をやめるか")]
    [SerializeField] private float _stopChaseTime = 1f;

    private NavMeshAgent _agent = default;
    private GameObject _player = default;
    private Transform _trans = default;
    private int _currentMoveIndex = 0;
    private float _moveSpeed = 0f;
    private float _chaseTime = 0f;
    private bool _isChasing = false;

    public void Init(NavMeshAgent agent, Transform trans)
    {
        _agent = agent;
        _trans = trans;

        _currentMoveIndex = 0;
        _isChasing = false;

        _moveSpeed = _agent.speed;
        _agent.SetDestination(_movePos[0].position);
    }

    public void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //指定の箇所を行ったり来たりするようにする
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            SwitchTarget();
        }

        //Playerを追跡する
        if (_isChasing)
        {
            _chaseTime += Time.deltaTime;
            _agent.SetDestination(_player.transform.position);

            //一定時間経ったら追跡をやめて、元の場所での移動に戻る
            if (_chaseTime >= _stopChaseTime)
            {
                _chaseTime = 0f;
                _isChasing = false;
                _agent.SetDestination
                    (_movePos[_currentMoveIndex % _movePos.Length].position);
                Debug.Log("Playerの追跡を終了します");
            }
        }
    }

    /// <summary> 進行先を次の位置に切り替える </summary>
    private void SwitchTarget()
    {
        _agent.speed = _moveSpeed;
        _currentMoveIndex++;
        _agent.SetDestination
            (_movePos[_currentMoveIndex % _movePos.Length].position);
    }

    /// <summary> Playerが視界の中に入っているか </summary>
    /// <param name="go"> Playerのオブジェクト </param>
    private void ChasePlayer(GameObject go)
    {
        var playerVec = go.transform.position - _trans.position;
        var angle = Vector3.Angle(_trans.forward, playerVec);

        if (angle <= _searchAngle)
        {
            Debug.Log("Player発見");
            _isChasing = true;
            _player = go;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Define.PLAYER_TAG))
        {
            //Playerを発見した(視界に入った)ときに追跡するようにする
            ChasePlayer(other.gameObject);
        }
    }
}

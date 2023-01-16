using Consts;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyMove
{
    [SerializeField] private Transform[] _movePos = new Transform[2];
    [Tooltip("視野の範囲")]
    [Range(0f, 180f)]
    [SerializeField] private float _searchAngle = 0f;
    [Tooltip("視野の距離")]
    [SerializeField] private float _searchDis = 1f;
    [Tooltip("何秒経ったらPlayerの追跡をやめるか")]
    [SerializeField] private float _stopChaseTime = 1f;

    private NavMeshAgent _agent = default;
    private GameObject _player = default;
    private Transform _trans = default;
    private int _currentMoveIndex = 0;
    private float _chaseTime = 0f;
    private bool _isChasing = false;

    public void Init(NavMeshAgent agent, Transform trans)
    {
        _agent = agent;
        _trans = trans;
        _player = GameObject.FindGameObjectWithTag(Define.PLAYER_TAG);

        _currentMoveIndex = 0;
        _isChasing = false;

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
        //追跡していない間は、Playerが視界に入っているか調べる
        else
        {
            if (ChasePlayer())
            {
                Debug.Log("Player発見");
                _isChasing = true;
            }
        }
    }

    /// <summary> 進行先を次の位置に切り替える </summary>
    private void SwitchTarget()
    {
        _currentMoveIndex++;
        _agent.SetDestination
            (_movePos[_currentMoveIndex % _movePos.Length].position);
    }

    /// <summary> Playerが視界に入っているか </summary>
    private bool ChasePlayer()
    {
        var target = _player.transform.position - _trans.position;
        var angle = Vector3.Angle(_trans.forward, target);

        return angle <= _searchAngle && target.magnitude <= _searchDis;
    }
}

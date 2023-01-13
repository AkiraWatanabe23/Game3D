using Consts;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour, IPause
{
    [SerializeField] private Transform[] _movePos = new Transform[2];
    [Tooltip("視界の範囲(*2)")]
    [Range(0f, 180f)]
    [SerializeField] private float _searchAngle = 0f;
    [Tooltip("何秒経ったらPlayerの追跡をやめるか")]
    [SerializeField] private float _stopChaseTime = 1f;

    [Header("テスト用")]
    [SerializeField] private bool _isPause = false;
    [SerializeField] private int _enemyHp = 10;

    private GameObject _player = default;
    private NavMeshAgent _agent = default;
    private int _currentMoveIndex = 0;
    private float _moveSpeed = 0f;
    private float _chaseTime = 0f;
    private bool _isChasing = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentMoveIndex = 0;
        _moveSpeed = _agent.speed;
        _isChasing = false;

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

        if (_enemyHp <= 0)
        {
            gameObject.SetActive(false);
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
        var playerVec = go.transform.position - gameObject.transform.position;
        var angle = Vector3.Angle(transform.forward, playerVec);

        if (angle <= _searchAngle)
        {
            Debug.Log("Player発見");
            _isChasing = true;
            _player = go;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        //ダメージ処理(ここはPlayerのタグでいいのかは確認)
        if (col.gameObject.CompareTag(Define.PLAYER_TAG))
        {
            var damage = col.gameObject.GetComponent<PlayerController>().Attack.AttackValue;
            _enemyHp -= damage;
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
        _agent.Stop();
    }

    [System.Obsolete]
    public void Resume()
    {
        _agent.Resume();
    }
}
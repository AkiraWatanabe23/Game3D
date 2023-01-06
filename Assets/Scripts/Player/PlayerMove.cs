using UnityEngine;

[System.Serializable]
public class PlayerMove : IPause
{
    [Header("移動系ステータス")]
    [SerializeField] private MoveType _move = MoveType.DEFAULT;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;
    [SerializeField] private float _rotateSpeed = 0.5f;

    [Header("テスト用")]
    [SerializeField] private bool _isPause = false;

    private Transform _trans;
    private Rigidbody _rb;
    private Vector3 moveDir = default;
    private float y = default;


    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float JumpPower { get => _jumpPower; set => _jumpPower = value; }

    public void Init(Transform trans, Rigidbody rb)
    {
        _trans = trans;
        _rb = rb;
    }
    
    public void FixedUpdate()
    {
        if (_isPause)
        {
            Pause();
        }
        else
        {
            Resume();
        }

        if (!_rb.isKinematic)
        {
            //TODO：Playerが進行方向をゆっくりと向くようにする
            float hol = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            y = _rb.velocity.y;
            if (Input.GetButtonDown("Jump") && y == 0f)
            {
                y = _jumpPower;
            }

            moveDir = Vector3.forward * ver + Vector3.right * hol;
            moveDir = Camera.main.transform.TransformDirection(moveDir);
            moveDir.y = 0;

            Vector3 forward = _rb.velocity;
            forward.y = 0;

            if (_move == MoveType.FORCE)
            {
                if (forward != Vector3.zero)
                {
                    _trans.forward = forward;
                }

                _rb.AddForce(moveDir.normalized * _moveSpeed + Vector3.up * y, ForceMode.Force);
            }
            else
            {
                if (moveDir != Vector3.zero)
                {
                    _trans.forward = moveDir;
                }

                if (_move == MoveType.VELO_ONE)
                {
                    _rb.velocity =
                        new Vector3(hol * _moveSpeed, 0, ver * _moveSpeed) + Vector3.up * y;
                }
                else if (_move == MoveType.VELO_TWO)
                {
                    _rb.velocity = moveDir.normalized * _moveSpeed + Vector3.up * y;
                }
            }

            float minAngle = 0f;
            float maxAngle = 90f;

            float objAngle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
            _trans.eulerAngles = new Vector3(0, objAngle, 0);
        }
    }

    public void Pause()
    {
        _rb.isKinematic = true;
    }

    public void Resume()
    {
        _rb.isKinematic = false;
    }

    /// <summary>
    /// Rigidbodyを用いた移動方法の選択
    /// </summary>
    private enum MoveType
    {
        DEFAULT,
        FORCE,
        VELO_ONE,
        VELO_TWO,
    }
}

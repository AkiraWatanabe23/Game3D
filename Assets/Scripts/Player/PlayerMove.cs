using UnityEngine;

[System.Serializable]
public class PlayerMove : IPause
{
    [Header("移動系ステータス")]
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

            //if (moveDir != Vector3.zero)
            //{
            //    _trans.forward = moveDir;
            //}
            if (forward != Vector3.zero)
            {
                _trans.forward = forward;
            }
        }

        //_rb.velocity =
        //new Vector3(hol * _moveSpeed, 0, ver * _moveSpeed) + Vector3.up * y;
        //moveDir.normalized * _moveSpeed + Vector3.up * y;
        _rb.AddForce(moveDir.normalized * _moveSpeed + Vector3.up * y, ForceMode.Force);
    }

    public void Pause()
    {
        _rb.isKinematic = true;
    }

    public void Resume()
    {
        _rb.isKinematic = false;
    }

    private enum MoveType
    {

    }
}

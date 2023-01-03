using Consts;
using UnityEngine;

[System.Serializable]
public class PlayerMove : IPause
{
    [Header("移動系ステータス")]
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;
    [SerializeField] private bool _isGround = false;

    [Header("テスト用")]
    [SerializeField] private bool _isPause = false;

    private Transform _trans;
    private Rigidbody _rb;
    private float _rotateSpeed = 0.2f;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float JumpPower { get => _jumpPower; set => _jumpPower = value; }

    public void Init(Transform trans, Rigidbody rb)
    {
        _trans = trans;
        _rb = rb;
        _isGround = false;
    }

    public void Update()
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
            //TODO：Playerが進行方向をすぐに向くようにする
            float hol = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            float y = _rb.velocity.y;
            if (Input.GetButtonDown("Jump") && _isGround)
            {
                y = _jumpPower;
                _isGround = false;
            }

            _rb.velocity =
                new Vector3(hol * _moveSpeed, 0, ver * _moveSpeed) + Vector3.up * y;

            //オブジェクトの回転
            //if (_rb.velocity.magnitude >= 0)
            //{
            //    //transform.rotation = Quaternion.Slerp
            //    //    (transform.rotation,
            //    //     Quaternion.LookRotation(_rb.velocity),
            //    //     _rotateSpeed);

            //    _trans.rotation = Quaternion.Slerp
            //        (_trans.rotation,
            //         Quaternion.LookRotation(_rb.velocity),
            //         _rotateSpeed);
            //}
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Define.GROUND_TAG))
        {
            _isGround = true;
        }
    }

    public void Pause()
    {
        _rb.isKinematic = true; //物理演算を行わない
    }

    public void Resume()
    {
        _rb.isKinematic = false;
    }
}

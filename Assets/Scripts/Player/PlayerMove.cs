using UnityEngine;

[System.Serializable]
public class PlayerMove : IPause
{
    [Header("移動系Status")]
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;

    //↓移動の計算等に用いる変数
    private Transform _trans;
    private Rigidbody _rb;
    private Vector3 _moveDir = default;
    private float _y = default;

    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float JumpPower { get => _jumpPower; set => _jumpPower = value; }

    public void Init(Transform trans, Rigidbody rb)
    {
        _trans = trans;
        _rb = rb;
    }

    public void Update()
    {
        //if (_isPause)
        //{
        //    Pause();
        //}
        if (GameManager.IsPause)
            Pause();
        else
            Resume();

        if (!_rb.isKinematic)
        {
            float hol = Input.GetAxisRaw("Horizontal");
            float ver = Input.GetAxisRaw("Vertical");

            _y = _rb.velocity.y;
            if (Input.GetButtonDown("Jump") && _y == 0f)
            {
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }

            _moveDir = Vector3.forward * ver + Vector3.right * hol;
            _moveDir = Camera.main.transform.TransformDirection(_moveDir);
            _moveDir.y = 0f;

            Vector3 forward = _rb.velocity;
            forward.y = 0;

            if (forward != Vector3.zero)
            {
                _trans.forward = forward;
            }
        }
    }
    
    public void FixedUpdate()
    {
        _rb.AddForce(_moveDir.normalized * _moveSpeed - _rb.velocity);
    }

    public void Pause()
    {
        _rb.isKinematic = true;
    }

    public void Resume()
    {
        _rb.isKinematic = false;
    }
}
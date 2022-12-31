using Consts;
using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [Header("移動系ステータス")]
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _jumpPower = 1f;
    [SerializeField] private bool _isGround = false;

    private Rigidbody _rb;

    public void Init(Rigidbody rb)
    {
        _rb = rb;
        _isGround = true;
    }

    public void Update()
    {
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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Define.GROUND_TAG))
        {
            _isGround = true;
        }
    }
}

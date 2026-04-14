using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRigidbody;
    private float _horizontalInput, _verticalInput;
    private Vector3 _movementDirection;

    private bool _isSliding;

    [Header("Transform")]
    [SerializeField] private Transform _orientationTransform;

    [Header("Movement Settings")]
    [SerializeField] float _MovementSpeed;
    [SerializeField] private KeyCode _movementKey;

    [Header("Jump Settings")]
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _canJump;
    [SerializeField] private float _jumpCooldown;

    [Header("Ground Check Settings")]
    [SerializeField] private float _playerHeight;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundDrag; //sürtünme

    [Header("Slide Settings")]
    [SerializeField] private KeyCode _slideKey;
    [SerializeField] private float _slideMultiplier;
    [SerializeField] private float _slideDrag; //sürtünme

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        _playerRigidbody.freezeRotation = true;
    }

    private void Update()
    {
        setInputs();
        SetPlayerDrag();
        LimitPlayerSpeed();
    }

    private void FixedUpdate()
    {
        setPlayerMovement();
    }

    private void setInputs()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        if(Input.GetKeyDown(_slideKey))
        {   Debug.Log("Sliding");
            _isSliding = true;
        }
        else if(Input.GetKeyDown(_movementKey))
        {   Debug.Log("Moving");
            _isSliding = false;
        }
        else if((Input.GetKey(_jumpKey)) && _canJump && IsGrounded())
        {
            _canJump = false;
            setPlayerJumping();
            Invoke(nameof(resetJumping), _jumpCooldown);
        }
    }

    private void setPlayerMovement()
    {
        _movementDirection = _orientationTransform.forward * _verticalInput + 
        _orientationTransform.right * _horizontalInput;

        if(_isSliding)
        {
            _playerRigidbody.AddForce(_movementDirection.normalized * _MovementSpeed * _slideMultiplier, ForceMode.Force);
        }
        else
        {
            _playerRigidbody.AddForce(_movementDirection.normalized * _MovementSpeed, ForceMode.Force);
        }
    }

        private void SetPlayerDrag()
    {
        if(_isSliding)
        {
            _playerRigidbody.linearDamping = _slideDrag;
        }
        else
        {
            _playerRigidbody.linearDamping = _groundDrag;
        }
    }

    private void LimitPlayerSpeed()
    {
        Vector3 flatVelocity = new Vector3(_playerRigidbody.linearVelocity.x, 0f, _playerRigidbody.linearVelocity.z);

        if(flatVelocity.magnitude > _MovementSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * _MovementSpeed;
            _playerRigidbody.linearVelocity = 
            new Vector3(limitedVelocity.x, _playerRigidbody.linearVelocity.y, limitedVelocity.z);
        }
    }

    private void setPlayerJumping()
    {
        _playerRigidbody.linearVelocity = new Vector3 (_playerRigidbody.linearVelocity.x, 0f, _playerRigidbody.linearVelocity.z);
        _playerRigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void resetJumping()
    {
        _canJump = true;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _groundLayer);
    }
}


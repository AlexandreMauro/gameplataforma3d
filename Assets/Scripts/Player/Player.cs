using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController CharacterController;
    public float gravity = -9.8f;
    public float JumpForce = 8f;
    public float turnSpeed = 1f;
    public float speed = 1f;
    public float RunSpeed = 1.5f;
    [Header("Key map")]
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode RunKey = KeyCode.LeftShift;

    [Header("Player States")]
    // Property to check if the player is grounded using the CharacterController's isGrounded property
    public bool IsGrounded;
    public bool CanRun = false;

    private Vector3 _SpeedVector;
    private float _Horizontal;
    private float _Vertical;
    private float _vSpeed = 1f;
    private Animator _animator;

    #region Get Inputs
    private void GetInputs()
    {
        _Horizontal = Input.GetAxisRaw("Horizontal");
        _Vertical = Input.GetAxisRaw("Vertical");

    }
    #endregion

    private void Start()
    {   // Get the CharacterController component attached to the player
        if (CharacterController == null)
        {
            CharacterController = GetComponent<CharacterController>();
        }

    }

    private void FixedUpdate()
    {
        GetInputs();
        
        
    }

    private void Update()
    {
       IsWalk();
       IsJumping();
       Walk();
       jump();
       Run();
        
       CharacterController.Move(_SpeedVector * Time.deltaTime);
        
    }

    private void Walk()
    {
        // Rotate the player based on horizontal input
        transform.Rotate(0, _Horizontal * turnSpeed * Time.deltaTime, 0);
        //Move the player forward based on vertical input
        _SpeedVector = transform.forward * _Vertical * speed;
    }

    private void jump()
    {
        // Apply gravity to the vertical speed
        _vSpeed -= gravity * Time.deltaTime;
        _SpeedVector.y = _vSpeed;
    }

    private void Run()
    {
        
        if(_Vertical != 0 && IsGrounded)
        {
            CanRun = true;

            if(Input.GetKey(RunKey) && CanRun)
                {
                _SpeedVector *= RunSpeed;
                _animator.speed = RunSpeed;
                }
            else
            {
                _animator.speed = 1;
            }
            
        }
    }

    #region Condidiontons for movement
    // Update the animator to reflect whether the player is running or not
    public void IsWalk()
    {

        if (_animator != null) _animator.SetBool("Run", _Vertical != 0);

        else _animator = GetComponentInChildren<Animator>();
   
    }
    // Check if the player is grounded and apply jump force if the jump key is pressed
    public void IsJumping()
    {
        IsGrounded = CharacterController.isGrounded;
        if (IsGrounded)
        {
            _vSpeed = 0f;
            if (Input.GetKeyDown(JumpKey))
            {
                _vSpeed = JumpForce;
            }
        }
    }
    #endregion
}

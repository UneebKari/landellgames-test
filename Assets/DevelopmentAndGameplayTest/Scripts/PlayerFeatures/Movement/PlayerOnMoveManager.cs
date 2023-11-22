using System;
using UnityEngine;

public class PlayerOnMoveManager : MonoBehaviour
{
    // TODO: Add Run & Jump

    #region Fields

    private CharacterController _cc;

    private Vector2 _moveDirection;
    private Vector3 _movePosition;

    [Header("Movement Stats")]
    [SerializeField] private float _walkSpeed = 7.5f;

    [Header("Physics Stats")]
    [SerializeField] private float _gravity = 20;
    [SerializeField] private float _jumpForce = 10f; // Adjust the jump force

    private bool _isJumping = false;

    #endregion

    #region Initialize Methods

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
    }

    #endregion

    #region Subscribe/Unsubscribe (OnEnable / OnDestroy)

    /// <summary>
    /// Subscribe to Events
    /// </summary>
    private void OnEnable()
    {
        MoveHandlerDataManager.OnMove += OnMove;
        MoveHandlerDataManager.OnRun += OnRun;
        MoveHandlerDataManager.OnJump += OnJump;
    }

    /// <summary>
    /// Unsubscribe to Events
    /// </summary>
    private void OnDestroy()
    {
        MoveHandlerDataManager.OnMove -= OnMove;
        MoveHandlerDataManager.OnRun -= OnRun;
        MoveHandlerDataManager.OnJump -= OnJump;
    }

    #endregion

    #region MonoBehaviour

    private void Update()
    {
        PlayerMovement();
    }

    #endregion

    #region Custom Methods

    private void OnMove(Vector2 direction)
    {
        _moveDirection = direction;
    }

    private void OnJump()
    {
        if (_cc.isGrounded)
        {
            // If the player is grounded, apply a vertical force to simulate a jump
            _isJumping = true;
            _movePosition.y = _jumpForce;
        }
    }

    private void OnRun()
    {
        Debug.Log("Run");
    }

    private void PlayerMovement()
    {
        ApplyMoveSpeed();

        ApplyGravity();

        if (!_cc.enabled) return;

        // If the player is jumping, reset the jump flag after one frame
        if (_isJumping)
        {
            _isJumping = false;
        }

        _cc.Move(_movePosition * Time.deltaTime);
    }

    private void ApplyMoveSpeed()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 movement = ((forward * _moveDirection.y) + (right * _moveDirection.x)) * _walkSpeed;

        _movePosition = new Vector3(movement.x, _movePosition.y, movement.z);
    }

    private void ApplyGravity()
    {
        if (_cc.isGrounded) return;

        _movePosition.y -= _gravity * Time.deltaTime;
    }

    #endregion
}




//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerOnMoveManager : MonoBehaviour
//{
//    //TODO: Add Run & Jump

//    #region Fields

//    private CharacterController _cc;


//    private Vector2 _moveDirection;
//    private Vector3 _movePosition;


//    [Header("Movement Stats")]
//    [SerializeField] private float _walkSpeed = 7.5f;



//    [Header("Physics Stats")]
//    [SerializeField] private float _gravity = 20;


//    #endregion

//    #region Initialize Methods

//    private void Awake()
//    {
//        _cc = GetComponent<CharacterController>();
//    }

//    #endregion


//    #region Subscribe/Unsubscribe (OnEnable / OnDestroy)

//    /// <summary>
//    /// Subscribe to Events
//    /// </summary>
//    private void OnEnable()
//    {
//        MoveHandlerDataManager.OnMove += OnMove;
//        MoveHandlerDataManager.OnRun += OnRun;
//        MoveHandlerDataManager.OnJump += OnJump;
//    }


//    /// <summary>
//    /// Unsubscribe to Events
//    /// </summary>
//    private  void OnDestroy()
//    {
//        MoveHandlerDataManager.OnMove -= OnMove;
//        MoveHandlerDataManager.OnRun -= OnRun;
//        MoveHandlerDataManager.OnJump -= OnJump;
//    }

//    #endregion


//    #region MonoBehaviour

//    private void Update()
//    {
//        PlayerMovement();
//    }

//    #endregion


//    #region Custom Methods

//    private void OnMove(Vector2 direction)
//    {
//        _moveDirection = direction;
//    }

//    private void OnJump()
//    {
//        // Add your jump logic here
//        Debug.Log("Jump!");
//    }
//    private void OnRun(Vector2 direction)
//    {
//        _moveDirection = direction;

//    }


//    private void PlayerMovement()
//    {
//        ApplyMoveSpeed();

//        ApplyGravity();

//        if(!_cc.enabled)return;

//        _cc.Move(_movePosition * Time.deltaTime);

//    }


//    private void ApplyMoveSpeed()
//    {
//        Vector3 forward = transform.TransformDirection(Vector3.forward);
//        Vector3 right = transform.TransformDirection(Vector3.right);
//        Vector3 movement = ((forward * _moveDirection.y) + (right * _moveDirection.x)) * _walkSpeed;

//        _movePosition = new Vector3(movement.x,_movePosition.y, movement.z);
//    }


//    private void ApplyGravity()
//    {
//        if(_cc.isGrounded) return;

//        _movePosition.y -= _gravity * Time.deltaTime;
//    }

//    #endregion



//}
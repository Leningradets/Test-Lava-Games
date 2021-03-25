using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(PlayerInput))]
public class PlayerMover : MonoBehaviour
{
    private PlayerInput _playerInput;
    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _lookPoint;
    private bool _isMoving;
    private bool _onTower;

    public bool OnTower => _onTower;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.Clicked += OnClicked;
    }

    private void Update()
    {
        if (!_onTower)
        {
            _animator.SetFloat("Move", _agent.velocity.magnitude / _agent.speed);

            if (_agent.velocity.magnitude == 0)
            {
                _isMoving = false;
            }
            else
            {
                _isMoving = true;
            }
        }
        if (!_isMoving || _onTower)
        {
            LookAtThePoint(_playerInput.GetClickPoint());
        }
    }

    private void OnDisable()
    {
        _playerInput.Clicked -= OnClicked;
    }

    public void MoveToPoint(Vector3 point)
    {
        _agent.SetDestination(point);
    }

    public void SetOnTower(bool value)
    {
        _onTower = value;
        _animator.SetBool("OnTower", _onTower);
    }

    public void SetLookPoint(Vector3 point)
    {
        if (point != null)
        {
            _lookPoint = point;
        } 
    }

    public void LookAtThePoint(Vector3 point)
    {
        var pointWithPlayerY = new Vector3(point.x, transform.position.y, point.z);
        transform.LookAt(pointWithPlayerY);
    }

    private void OnClicked(Vector3 point)
    {
        if (!_onTower)
        {
            _agent.SetDestination(point);
        }
    }
}

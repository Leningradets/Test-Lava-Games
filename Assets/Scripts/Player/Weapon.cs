using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;
    private float _bulletForce;

    private PlayerMover _playerMover;
    private PlayerInput _playerInput;
    private Animator _animator;

    private bool _clicked;

    private float _timeAfterLastShoot;

    public void SetTimeBetweenShoot(float timeBetweenShoot)
    {
        _timeBetweenShoot = timeBetweenShoot;
    }

    public void SetBulletForce(float bulletForce)
    {
        _bulletForce = bulletForce;
    }

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.Clicked += OnClicked;
        _playerInput.Reliased += OnReliased;
    }

    private void OnDisable()
    {
        _playerInput.Clicked -= OnClicked;
        _playerInput.Reliased -= OnReliased;
    }

    private void Update()
    {
        _timeAfterLastShoot += Time.deltaTime;

        if (_playerMover.OnTower)
        {
            if (_clicked)
            {
                if (_timeAfterLastShoot >= _timeBetweenShoot)
                {
                    Shoot();
                }
            }
        }
    }

    private void Shoot()
    {
        _animator.SetTrigger("Shoot");

        var bullet = Instantiate(_bullet, _bulletSpawnPoint.position, Quaternion.identity);
        bullet.transform.LookAt(_playerInput.GetClickPoint());
        bullet.SetForce(_bulletForce);

        _timeAfterLastShoot = 0;
    }

    private void OnClicked(Vector3 arg0)
    {
        _clicked = true;
    }

    private void OnReliased()
    {
        _clicked = false;
    }
}

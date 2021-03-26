using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerProperties _playerProperties;

    private NavMeshAgent _agent;
    private Weapon _weapon;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _weapon = GetComponent<Weapon>();

        _agent.speed = _playerProperties.Speed;
        _weapon.SetTimeBetweenShoot(_playerProperties.TimeBetweenShoot);
        _weapon.SetBulletForce(_playerProperties.BulletForce);
    }
}

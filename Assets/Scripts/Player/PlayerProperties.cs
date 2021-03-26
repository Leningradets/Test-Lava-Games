using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerProperties : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenShoot;
    [SerializeField] private float _bulletForce;

    public float Speed => _speed;
    public float TimeBetweenShoot => _timeBetweenShoot;
    public float BulletForce => _bulletForce;
}

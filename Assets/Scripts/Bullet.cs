using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _bloodBurst;
    [SerializeField] private ParticleSystem _burst;

    private float _force;

    private Transform _transform;

    public void SetForce(float force)
    {
        _force = force;
    }

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        Debug.DrawRay(_transform.position, _transform.forward * _speed * Time.deltaTime * 2);

        if (Physics.Raycast(_transform.position, _transform.forward, out RaycastHit hit, _speed * Time.deltaTime * 2))
        {
            if (hit.transform.gameObject.TryGetComponent(out RagdollBone ragdollBone))
            {
                ragdollBone.GetComponentInParent<RagdollActivator>().ActivateRagdoll();
                Debug.Log(_force);
                ragdollBone.Bounce(transform.forward * _force);
                Instantiate(_bloodBurst, hit.point, Quaternion.identity);
            }

            Instantiate(_burst, hit.point, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

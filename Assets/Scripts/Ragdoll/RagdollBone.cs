using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RagdollBone : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Activate()
    {
        _rigidbody.isKinematic = false;
    }

    public void Bounce(Vector3 force)
    {
        _rigidbody.AddForce(force);
    }
}

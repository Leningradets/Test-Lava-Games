using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBone : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public void Activate()
    {
        _rigidbody.isKinematic = false;
    }

    public void Bounce(float force, Vector3 position, float radius)
    {
        _rigidbody.AddExplosionForce(force, position, radius);
    }
}

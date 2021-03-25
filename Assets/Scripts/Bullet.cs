using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float speed;

    public float Speed { get => speed; set => speed = value; }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed);

        Debug.DrawRay(transform.position, transform.forward);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            if (hit.transform.gameObject.TryGetComponent(out RagdollBone ragdollBone))
            {
                ragdollBone.GetComponentInParent<RagdollActivator>().ActivateRagdoll();
                ragdollBone.Bounce(100, hit.point, 0);
            }

            Destroy(gameObject);
        }
    }
}

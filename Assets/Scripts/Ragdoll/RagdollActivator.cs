using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollActivator : MonoBehaviour
{
    private RagdollBone[] _ragdollBones;

    private void Start()
    {
        _ragdollBones = GetComponentsInChildren<RagdollBone>();
    }

    public void ActivateRagdoll()
    {
        foreach (var ragdollBone in _ragdollBones)
        {
            ragdollBone.Activate();
        }
    }
}

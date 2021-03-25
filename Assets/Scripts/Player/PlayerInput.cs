using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private Camera _camera;
    private PlayerMover _playerMover;
    private RaycastHit hit;

    public event UnityAction<Vector3> Clicked;
    public event UnityAction Reliased;

    void Start()
    {
        _camera = Camera.main;
        _playerMover = GetComponent<PlayerMover>();
    }

    void Update()
    {
        if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Clicked?.Invoke(hit.point);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Reliased?.Invoke();
        }
    }

    public Vector3 GetClickPoint()
    {
        return hit.point;
    }
}

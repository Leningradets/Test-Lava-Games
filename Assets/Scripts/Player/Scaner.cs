using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scaner : MonoBehaviour
{
    public event UnityAction<PlayerMover> PlayerOn;

    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<FiringPosition>(out FiringPosition firingPoint))
        {
            _playerMover.MoveToPoint(firingPoint.transform.position);
            _playerMover.SetOnTower(true);
            PlayerOn?.Invoke(_playerMover);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<FiringPosition>(out FiringPosition firingPoint))
        {
            _playerMover.SetOnTower(false);
        }
    }
}

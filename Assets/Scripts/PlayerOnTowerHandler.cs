using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnTowerHandler : MonoBehaviour
{
    [SerializeField] private Scaner _playerScaner;

    private PlayerMover _playerMover;

    private void Start()
    {
        gameObject.SetActive(false);
        _playerScaner.PlayerOn += OnPlayerOn;
    }

    private void OnDestroy()
    {
        _playerScaner.PlayerOn -= OnPlayerOn;
    }

    public void OnPlayerOn(PlayerMover playerMover)
    {
        _playerMover = playerMover;
        gameObject.SetActive(true);
        _playerScaner.PlayerOn -= OnPlayerOn;
    }

    public void RemovePlayerFromTower()
    {
        if(_playerMover != null)
        {
            _playerMover.SetOnTower(false);
        }
        gameObject.SetActive(false);
        _playerScaner.PlayerOn += OnPlayerOn;
    }
}

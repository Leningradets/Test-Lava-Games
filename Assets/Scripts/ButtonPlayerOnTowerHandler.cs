using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayerOnTowerHandler : MonoBehaviour
{
    [SerializeField] private Scaner _playerScaner;

    private PlayerMover _playerMover;

    private void Start()
    {
        gameObject.SetActive(false);
        _playerScaner.PlayerOn += OnPlayerOnTower;
    }

    private void OnDestroy()
    {
        _playerScaner.PlayerOn -= OnPlayerOnTower;
    }

    public void OnPlayerOnTower(PlayerMover playerMover)
    {
        _playerMover = playerMover;
        gameObject.SetActive(true);
        _playerScaner.PlayerOn -= OnPlayerOnTower;
    }

    public void RemovePlayerFromTower()
    {
        if(_playerMover != null)
        {
            _playerMover.SetOnTower(false);
        }
        gameObject.SetActive(false);
        _playerScaner.PlayerOn += OnPlayerOnTower;
    }
}

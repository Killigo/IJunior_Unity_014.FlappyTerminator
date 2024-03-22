using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour, IDead
{
    private PlayerMover _mover;

    public event Action GameOver;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _mover.ResetPlayer();
    }

    public void Die()
    {
        _mover.ResetPlayer();
        GameOver?.Invoke();
    }
}

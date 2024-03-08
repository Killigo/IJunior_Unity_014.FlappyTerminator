using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour, IDied
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _mover.ResetPlayer();
    }

    public void Die()
    {
        _mover.ResetPlayer();
    }
}

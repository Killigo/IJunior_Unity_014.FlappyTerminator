using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _mover.ResetPlayer();
    }

    public void Die()
    {
        Debug.Log("Player is Died");
        _mover.ResetPlayer();
    }
}

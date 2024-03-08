using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : CharacterShooter
{
    [SerializeField] private KeyCode _shoot = KeyCode.Mouse0;

    private void Update()
    {
        if (Input.GetKeyDown(_shoot))
        {
            Shoot();
        }
    }
}

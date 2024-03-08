using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float Speed = 5f;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();
}

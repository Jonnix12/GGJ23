using System;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        _animator.SetTrigger("Hit");
    }
}

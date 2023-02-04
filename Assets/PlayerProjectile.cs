using System;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnCollisionEnter(Collision collision)
    {
        _animator.SetTrigger("Hit");
    }
}

using UnityEngine;

public class ShotHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Shot()
    {
        _animator.SetTrigger("Shot");
    }
}

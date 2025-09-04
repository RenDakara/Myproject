using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayRunningAnimation(bool state)
    {
        _animator.SetBool(CharacterAnimatorData.Params.IsRunning, state);
    }

    public void PlayAttackAnimation(bool state)
    {
        _animator.SetBool(CharacterAnimatorData.Params.IsAttacking, state);
    }
}

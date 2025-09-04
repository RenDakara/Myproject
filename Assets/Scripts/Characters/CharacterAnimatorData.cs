using UnityEngine;

public static class CharacterAnimatorData
{
  public static class Params
    {
        public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
        public static readonly int IsAttacking = Animator.StringToHash(nameof(IsAttacking));
    }
}
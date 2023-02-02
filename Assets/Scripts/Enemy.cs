using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public event Action OnEnmeyDied;

   private int _hp;

   private float _moveSpeed;

   private float _fireRate;
   //projectil

   private void Update()
   {
      
      
      CheckHp();
   }

   private void CheckHp()
   {
      if (_hp <= 0)
      {
         OnEnmeyDied?.Invoke();
      }
   }
}

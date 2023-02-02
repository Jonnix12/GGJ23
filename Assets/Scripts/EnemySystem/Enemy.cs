using System;
using ProJectil;
using UnityEngine;

public class Enemy : MonoBehaviour , IDisposable
{
   public event Action<Enemy> OnEnemyDied;

   private int _hp;

   private float _moveSpeed;

   private Range _range;
   private Vector2 _fireRate;
   private Projectil _projectil;

   public void Init(int hp, float moveSpeed, Projectil projectil, Vector2 fireRate,Range range)
   {
      _hp = hp;
      _projectil = projectil;
      _moveSpeed = moveSpeed;
      _fireRate = fireRate;
      _range = range;
   }

   private void Update()
   {
      
      
      CheckHp();
   }

   private void CheckHp()
   {
      if (_hp <= 0)
      {
         OnEnemyDied?.Invoke(this);
      }
   }

   public void Dispose()
   {
      Destroy(this);
   }
}

public enum EnemyShotType
{
   Shotgun,
   Rifle,
   Circle
}

public enum Range
{
   Short,
   Long
}

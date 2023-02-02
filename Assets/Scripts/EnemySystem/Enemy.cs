using System;
using ProJectil;
using UnityEngine;

public class Enemy : MonoBehaviour , IDisposable
{
   public event Action<Enemy> OnEnemyDied;

   private int _hp;

   private float _moveSpeed;

   private Vector2 _dircsation;

   private Range _range;
   private Vector2 _fireRate;
   private Projectil _projectil;

   public Range Range => _range;
   public void Init(int hp, float moveSpeed, Projectil projectil, Vector2 fireRate,Range range)
   {
      _hp = hp;
      _projectil = projectil;
      _moveSpeed = moveSpeed;
      _fireRate = fireRate;
      _range = range;
   }


   public void UpdateDircastion(Vector2 dirication)
   {
      _dircsation = dirication;
   }
   
   private void Update()
   {
      transform.position = Vector2.MoveTowards(transform.position, _dircsation, _moveSpeed * Time.deltaTime);
      
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

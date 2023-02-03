using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour , IDisposable
{
   public event Action<Enemy> OnEnemyDied;

   private int _hp;

   private float _moveSpeed;

   private Vector2 _dircsation;

   private Range _rangeType;
   private float _rage;
   private float _playerOfSet;
   private Vector2 _fireRate;
   private Projectile.Projectile _projectil;

   public Range RangeType => _rangeType;
   public void Init(int hp, float moveSpeed, Projectile.Projectile projectil, Vector2 fireRate,Range rangeType)
   {
      _hp = hp;
      _projectil = projectil;
      _moveSpeed = moveSpeed;
      _fireRate = fireRate;
      _rangeType = rangeType;

      StartCoroutine(Move());
   }

   public void SetRange(float range,float playerOfSet)
   {
      _rage = range;
      _playerOfSet = playerOfSet;
   }

   private IEnumerator Move()
   {
      while (true)
      {
         Vector2 vector2 = Player.Player.Instance.transform.position;
         var x = Random.Range(vector2.x + _playerOfSet, vector2.x + _rage);
         var y = Random.Range(vector2.y + _playerOfSet, vector2.y + _rage);

         _dircsation = new Vector2(x, y);
         yield return new WaitForSeconds(Random.Range(0,5));
      }
   }
   
   private void Update()
   {
      transform.position = Vector2.MoveTowards(transform.position,_dircsation , _moveSpeed * Time.deltaTime);

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

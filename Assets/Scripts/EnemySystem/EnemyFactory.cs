﻿using System;
using Pool;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyFactory : MonoSingleton<EnemyFactory>
    {
        [SerializeField] private EnemyPool _pool;
        
        public Enemy GetEnemy(EnemyData enemyData)
        {
            Enemy enemy = _pool.PullEnemy(enemyData.ID);
         
            enemy.Init(enemyData.Hp,enemyData.MoveSpeed,enemyData.Projectil,enemyData.FireRate,enemyData.Range,enemyData.ID);

            return enemy;
        }

    }
}
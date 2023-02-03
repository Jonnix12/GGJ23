using System;
using UnityEngine;

namespace EnemySystem
{
    [Serializable]
    public class EnemyGtoup
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private int _numberOfEnemy;
        public bool _isEmpty = false;

        public Enemy GetEnemy()
        {
            if (_numberOfEnemy > 0)
            {
                _numberOfEnemy--;
                return EnemyFactory.Instance.GetEnemy(_enemyData);
            }

            _isEmpty = true;
            return null;
        }
    }
}
﻿using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _hp;
        
        public void DoDamage(int demage)
        {
            _hp -= demage;
        }
    }
}
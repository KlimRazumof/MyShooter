using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Структура для записи информации столкновения пули.
    /// </summary>
    public struct InfoAboutShotCollision
    {
        private readonly float _damage;
        private readonly Vector3 _direction;

        /// <summary>
        /// Конструктор структуры.
        /// </summary>
        /// <param name="damage">Урон.</param>
        /// <param name="direction"></param>
        public InfoAboutShotCollision(float damage, Vector3 direction)
        {
            _damage = damage;
            _direction = direction;
        }

        /// <summary>
        /// Получение значения урона конкретного боеприпаса.
        /// </summary>
        public float Damage
        {
            get
            {
                return _damage;
            }
        }

        /// <summary>
        /// Свойство для установки рекашета пули.
        /// </summary>
        public Vector3 Direction
        {
            get
            {
                return _direction;
            }
        }
    }

}


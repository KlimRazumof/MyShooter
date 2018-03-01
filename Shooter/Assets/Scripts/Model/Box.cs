using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class Box : BaseObjectScene, ISetDamage
    {
        private float _hp = 100.0f;
        private float _timeToDie = 3.0f;

        public float HealthPoints
        {
            get { return _hp; }
            private set { _hp = value; }
        }

        public void SetDamage(InfoAboutShotCollision info)
        {
            Debug.Log(_hp);
            if (HealthPoints > 0)
            {
                HealthPoints -= info.Damage;
            }

            if (HealthPoints <= 0)
            {
                _hp = 0;
                BaseColor = Color.red;
                Destroy(BaseGameObject, _timeToDie);
            }
        }
    }
}

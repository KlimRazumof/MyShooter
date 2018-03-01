using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Model
{
    /// <summary>
    /// Класс, описывающий поведение любой пули.
    /// </summary>
    public class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            SetDamage(collision.gameObject.GetComponent<ISetDamage>());
            Destroy(BaseGameObject);
        }
        
        /// <summary>
        /// Метод нанесения урона.
        /// </summary>
        /// <param name="setDamage">Объект интерфейса</param>
        private void SetDamage(ISetDamage setDamage)
        {
            if(setDamage != null)
                setDamage.SetDamage(new InfoAboutShotCollision(CurrentDamage, transform.forward));
        }
    }
}


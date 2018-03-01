using System.Collections;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Model
{
    /// <summary>
    /// Базовый класс вооружения
    /// </summary>
    public abstract class Weapon : BaseObjectScene
    {
        [SerializeField] protected Transform GunPoint;
        [SerializeField] protected float Force = 350.0F;
        [SerializeField] protected float CoolDownTime { get; set; }
        [SerializeField] protected Ammunition WeaponAmmunition;
        protected bool BeAbleShoot = true;
        protected Timer Timer = new Timer();

        
        protected virtual void Update()
        {
            Timer.UpdateTimer();
            if (Timer.IsEvent())
            {
                BeAbleShoot = true;
            }
        }

        /// <summary>
        /// Свойство для получения и установки вида боеприпасов.
        /// </summary>
        public Ammunition Ammunition
        {
            get { return WeaponAmmunition; }
            set { WeaponAmmunition = value; }
        }

        /// <summary>
        /// Метод стрельбы.
        /// </summary>
        public abstract void Fire(Ammunition ammunition);

        /// <summary>
        /// Корутина реализиющая задержку выстрела.
        /// </summary>
        /// <param name="time">Время задержки</param>
        /// <returns></returns>
        protected override IEnumerator CoolDown(int time)
        {
            Fire(WeaponAmmunition);
            yield return new WaitForSeconds(time);
            BeAbleShoot = false;
        }
    }

}


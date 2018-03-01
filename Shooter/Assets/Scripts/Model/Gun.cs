using UnityEditorInternal;
using UnityEngine;

namespace Assets.Scripts.Model
{
    /// <summary>
    /// Класс, определяющий поведение пистолета.
    /// </summary>
    public sealed class Gun : Weapon
    {
        /// <summary>
        /// Реализация стрельбы из пистолета.
        /// </summary>
        public override void Fire(Ammunition ammunition)
        {
            if (BeAbleShoot)
            {
                if (ammunition)
                {
                    var ammo = Instantiate(ammunition, GunPoint.position, GunPoint.rotation);
                    if (ammo != null)
                        ammo.RigidBody.AddForce(GunPoint.forward * Force);
                    BeAbleShoot = false;
                    Timer.StartTimer(CoolDownTime = 0.2F);
                }
                else
                {
                    //Raycast
                }
            }
        }
    }
}


using UnityEngine;

namespace Assets.Scripts.Model
{
    /// <summary>
    /// Базовый класс всех боеприпасов.
    /// </summary>
    public abstract class Ammunition : BaseObjectScene
    {
        [SerializeField] protected float TimeToDestruction = 10.0F;
        [SerializeField] protected float BaseDamage = 10.0F;
        protected float CurrentDamage;
        protected float Mass = 0.01F;

        protected override void Awake()
        {
            base.Awake();
            Destroy(gameObject,TimeToDestruction);
            CurrentDamage = BaseDamage;
            RigidBody.mass = Mass;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    /// <summary>
    /// Интерфейс получения урона.
    /// </summary>
    public interface ISetDamage
    {
        float HealthPoints { get; }
        void SetDamage(InfoAboutShotCollision info);
    }
}


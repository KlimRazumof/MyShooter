using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Базовый класс всех контроллеров.
    /// </summary>
    public abstract class BaseController : MonoBehaviour
    {
        /// <summary>
        /// Свойство, для получения и установки значения включения и выключения контроллера.
        /// </summary>
        public bool Enable { get; private set; }

        /// <summary>
        /// Метод включения контроллера.
        /// </summary>
        public virtual void ControllerOn()
        {
            Enable = true;
        }

        /// <summary>
        /// Метод выключения контроллера.
        /// </summary>
        public virtual void ControllerOff()
        {
            Enable = false;
        }
    }
}


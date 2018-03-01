using System.Collections;
using Assets.Scripts.Model;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Класс контроллера фонарика.
    /// </summary>
    public sealed class FlashLightController : BaseController
    {
        private FlashLight _flashLight;
        private FlashLightView _flashLightView;

        #region Unity Methods
        private void Start()
        {
            _flashLight = FindObjectOfType<FlashLight>();
            _flashLightView = FindObjectOfType<FlashLightView>();
        }

        private void Update()
        {
            if(!Enable) return;
            StartCoroutine(ValueIndicatorCoroutine());
            if (_flashLight != null)
                _flashLight.SetRotation();
        }
        #endregion

        private IEnumerator ValueIndicatorCoroutine()
        {
            yield return new WaitForSeconds(1.0F); // Это не работает. Переделать! 
            _flashLightView.SetChargeIndicator(_flashLight.WorkTime);
        }

        /// <summary>
        /// Переопределенный метод включения фонарика.
        /// </summary>
        public override void ControllerOn()
        {
            if (Enable) return;

            base.ControllerOn();

            if (_flashLight != null)
                _flashLight.SwitchFlashLight(true);
        }

        /// <summary>
        /// Переопределенный метод выключения фонарика.
        /// </summary>
        public override void ControllerOff()
        {
            if (!Enable) return;

            base.ControllerOff();

            if (_flashLight != null)
                _flashLight.SwitchFlashLight(false);
        }

        /// <summary>
        /// Контроллер переключателя фонарика для InputController.
        /// </summary>
        public void Switch()
        {
            if (Enable)
            {
                ControllerOff();
            }
            else
            {
                ControllerOn();
            }
        }
    }
}


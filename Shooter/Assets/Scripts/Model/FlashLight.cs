using System.Collections;
using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Model
{
    /// <summary>
    /// Класс, описывающий поведение фонарика.
    /// </summary>
    public sealed class FlashLight : BaseObjectScene
    {
        private Light _light;
        private Transform _camFollow;
        private Vector3 _vectorSetOff;
        private const float Speed = 10.0F;
        private int _workTime = 10;
        private bool _isCharged;

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _camFollow = Camera.main.transform;
            _vectorSetOff = transform.position - _camFollow.position;
        }

        #endregion

        #region Properties

         /// <summary>
        /// Свойство получения и записи времени для передачи в скролбар.
        /// </summary>
        public int WorkTime
        {
            get { return _workTime; }
            set { _workTime = value; }
        }

        #endregion

        #region Методы класса
        /// <summary>
        /// Метод включения фонарика.
        /// </summary>
        /// <param name="value">True - вкл. False - выкл.</param>
        public void SwitchFlashLight(bool value)
        {
            if (_light != null)
            {
                _light.enabled = value;

                if(!_isCharged)
                    StartCoroutine(CoolDown(_workTime));
            }

            transform.position = _camFollow.position + _vectorSetOff;
            transform.rotation = _camFollow.rotation;
        }

        /// <summary>
        /// Метод плавного передвижения света фонарика в зависимости от карты.
        /// </summary>
        public void SetRotation()
        {
            if(!_light) return;

            transform.position = _camFollow.position + _vectorSetOff;
            transform.rotation = Quaternion.Lerp(transform.rotation, _camFollow.rotation, Speed * Time.deltaTime);
        }

        /// <summary>
        /// Корутина для заряжения и разряжения батареи фонарика.
        /// </summary>
        /// <param name="time">Время разряжения</param>
        /// <returns></returns>
        protected override IEnumerator CoolDown(int time)
        {
            // !Здесь нужно разбить на две корутины и останавливать их. 
            // Переделай после реализации всех классов по оружию!
            if (time == 10)
            {
                while (time != 0)
                {
                    WorkTime = time;
                    time--;
                    yield return new WaitForSeconds(1.0F);
                }
                _light.enabled = false;
                _isCharged = true;
            }

            if (time == 0)
            {
                while (time != 10)
                {
                    time++;
                    WorkTime = time;
                    yield return new WaitForSeconds(1.0F);
                }
                _isCharged = false;
            }

            yield return null;
        }
        #endregion
    }
}


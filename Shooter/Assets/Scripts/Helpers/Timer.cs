using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    /// <summary>
    /// Класс, описывающий поведение игрового таймера.
    /// </summary>
    public class Timer
    {
        private DateTime _starTime;
        private float _countDown = -1;

        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// Отсчет времени.
        /// </summary>
        /// <param name="delay">Время отсчета</param>
        public void StartTimer(float delay)
        {
            _countDown = delay;
            _starTime = DateTime.Now;
            Duration = TimeSpan.Zero;
        }

        public void UpdateTimer()
        {
            if (_countDown > 0)
            {
                Duration = DateTime.Now - _starTime;
                if (Duration.TotalSeconds > _countDown)
                {
                    _countDown = 0;
                }
            }
            else if (_countDown == 0)
            {
                _countDown = -1;
            }
        }

        public bool IsEvent()
        {
            return _countDown == 0;
        }

    }
}

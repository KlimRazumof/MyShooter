using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.View
{
    /// <summary>
    /// Класс для отображения заряда батареии фонарика.
    /// </summary>
    public sealed class FlashLightView : ScreenUI
    {
        private Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();
        }

        /// <summary>
        /// Метод, принимающий время жля отображения на слайдере.
        /// </summary>
        /// <param name="time">Время работы фонарика</param>
        public void SetChargeIndicator(int time)
        {
            if (_slider != null)
                _slider.value = time;
        }
    }
}
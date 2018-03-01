using Assets.Scripts.Controllers;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Контроллер для стрельб из любого типа оружия.
    /// </summary>
    public class WeaponController : BaseController
    {
        private Weapon _weapons;
        private Ammunition _ammunition;
        private int _mouseButton = (int) MouseButton.LeftMouse;

        private void Update()
        {
            if (!Enable) return;
            if (Input.GetMouseButton(_mouseButton))
            {
                if (_weapons)
                {
                    _weapons.Fire(_ammunition);
                }
            }
        }

        public void ControllerOn(Weapon weapons)
        {
            if (Enable) return;
            base.ControllerOn();
            _weapons = weapons;
            _weapons.Visible = true;
            if (_weapons.Ammunition != null)
                _ammunition = _weapons.Ammunition;
        }

        public override void ControllerOff()
        {
            if (!Enable) return;
            base.ControllerOff();
            _weapons.Visible = false;
            _weapons = null;
            _ammunition = null;
        }
    }
}

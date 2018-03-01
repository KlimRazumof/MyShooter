using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    /// <summary>
    /// Класс, позволяющий пользователю управлять персонажем.
    /// </summary>
    public sealed class InputController : BaseController
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Main.GetSingleTonField.GetFlashLightController.Switch();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChooseWeapon(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChooseWeapon(1);
            }
        }

        private void ChooseWeapon(int choice)
        {
            Main.GetSingleTonField.GetWeaponController.ControllerOff();
            var temporaryWeapon = Main.GetSingleTonField.GetObjectInBag.WeaponOfPlayer[choice];

            if (temporaryWeapon)
            {
                Main.GetSingleTonField.GetWeaponController.ControllerOn(temporaryWeapon);
            }
        }
    }

}


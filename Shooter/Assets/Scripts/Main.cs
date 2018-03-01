using Assets.Scripts.Controllers;
using Assets.Scripts.Helpers;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        [HideInInspector] public FlashLightController GetFlashLightController { get; private set; }
        [HideInInspector] public ObjectManager GetObjectInBag { get; private set; }
        [HideInInspector] public WeaponController GetWeaponController { get; private set; }

        [HideInInspector] public static Main GetSingleTonField { get; private set; }

        private void Start()
        {
            GetSingleTonField = this;

            var gameControllers = new GameObject("GameControllers");

            gameControllers.AddComponent<InputController>();
            GetFlashLightController = gameControllers.AddComponent<FlashLightController>();
            GetWeaponController = gameControllers.AddComponent<WeaponController>();
            GetObjectInBag = gameControllers.AddComponent<ObjectManager>();
            
            DontDestroyOnLoad(gameObject);
        }
    }

}


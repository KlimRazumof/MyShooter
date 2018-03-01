using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Assets.Scripts.Helpers
{
    public class ObjectManager : MonoBehaviour
    {
        [SerializeField] private Weapon[] _weaponOfPlayer;
        private Transform _player;

        public Weapon[] WeaponOfPlayer
        {
            get { return _weaponOfPlayer; }
        }

        private void Start()
        {
            _player = FindObjectOfType<FirstPersonController>().transform;
            if (!_player) return;

            _weaponOfPlayer = _player.GetComponentsInChildren<Weapon>();

            if (WeaponOfPlayer.Length > 0)
            {
                foreach (var weapon in WeaponOfPlayer)
                {
                    Debug.Log(weapon);
                    weapon.Visible = false;
                }
            }
        }
    }
}

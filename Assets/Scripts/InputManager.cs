using Contreras.Snowman;
using ContrerasAlex.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Contreras.Snowman
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private RotateControl rotateController;
        private PlayerInputActions inputScheme;

        private void Awake()
        {
            inputScheme = new PlayerInputActions();
            rotateController.Initialize(inputScheme.Player.Rotate);
        }
        private void OnEnable()
        {
            var _ = new QuitHandler(inputScheme.Player.Quit);
        }
    }

}

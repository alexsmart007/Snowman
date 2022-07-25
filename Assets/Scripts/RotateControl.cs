using ContrerasAlex.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Contreras.Snowman
{
    public class RotateControl : MonoBehaviour
    {
        [SerializeField] private float speed = 100f;
        private InputAction rotateAction;
        private float verticalTilt;
        private float horizontalTilt;

        private CameraController mainCamera;
        private PlayerController player;

        private void Start()
        {
            player = FindObjectOfType<PlayerController>();  // Find player
            mainCamera = FindObjectOfType<CameraController>();  // Find camera
        }

        public void Initialize(InputAction rotateAction)
        {
            this.rotateAction = rotateAction;
            this.rotateAction.Enable();
        }
        private void FixedUpdate()
        {
            verticalTilt = this.rotateAction.ReadValue<Vector2>().y;
            horizontalTilt = this.rotateAction.ReadValue<Vector2>().x;
            player.Move(verticalTilt, horizontalTilt, mainCamera.transform.right);
            mainCamera.CameraTilt(verticalTilt, horizontalTilt);
        }
    }
}

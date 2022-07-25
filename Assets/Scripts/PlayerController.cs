using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Contreras.Snowman
{
    public class PlayerController : MonoBehaviour
    {
        public enum State
        {
            WAIT,
            NORMAL,
            DEAD,
            VICTORY,
            STATES
        }

        Animator anim;

        [HideInInspector] public State currentState;
        [HideInInspector] public Rigidbody rigidBody;

        [HideInInspector] public Vector3 floorNormal;

        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private float groundCheckRadius;

        public float maxSpeed;

        [SerializeField] private float moveForce;
        [SerializeField] private float victoryForce;

        // Start is called before the first frame update
        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();  // Get rigidbody component
            anim = this.gameObject.transform.GetChild(0).GetComponent<Animator>(); //Get animator component 
            anim.SetBool("isVictory", false);
        }

        public void Move(float verticalTilt, float horizontalTilt, Vector3 right)
        {
            // Only apply movement when the player is grounded
            if (OnGround())
            {
                CalculateFloorNormal();

                // No input from player
                if (horizontalTilt == 0.0f && verticalTilt == 0.0f && rigidBody.velocity.magnitude > 0.0f)
                {
                    rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, Vector3.zero, moveForce * 0.1f * Time.deltaTime); // Slow down
                }
                else
                {
                    // Get a direction perpendicular to the camera's right vector and the floor's normal (The forward direction)
                    Vector3 forward = Vector3.Cross(right, floorNormal);
                    // Apply moveForce scaled by verticalTilt in the forward direction (Half the move force when moving backwards)
                    Vector3 forwardForce = (verticalTilt > 0.0f ? 1.0f : 0.5f) * moveForce * verticalTilt * forward;
                    // Apply moveForce scaled by horizontalTilt in the right direction
                    Vector3 rightForce = moveForce * horizontalTilt * right;
               
                    Vector3 forceVector = forwardForce + rightForce;

                    rigidBody.AddForce(forceVector);
                }
            }
        }

        public bool OnGround()
        {
            return Physics.CheckSphere(transform.position - (Vector3.up * 0.5f), groundCheckRadius, whatIsGround);
        }

        private void CalculateFloorNormal()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, whatIsGround))
            {
                floorNormal = hit.normal;
            }
        }



    }
}

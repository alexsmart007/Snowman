using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Contreras.Snowman
{
    public class EndTrigger : MonoBehaviour
    {
        public GameManager gameManager;
        [SerializeField] private Animator anim;

        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                anim.SetBool("isVictory", true);
                StartCoroutine(gameManager.Victory());
            }

        }
    }
}

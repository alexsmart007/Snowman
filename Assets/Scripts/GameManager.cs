using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Contreras.Snowman
{
    public class GameManager : MonoBehaviour
    {
        private PlayerController player;
        private Coroutine victoryCoroutine;

        private string currentScene;

        [SerializeField]
        private string nextScene;

        public Camera mainCam;
        public Camera victoryCam;

        public Transform deathHeight;

        public int playerScore;

        public float timer;

        public GameObject completeLevelUI;

        // Start is called before the first frame update
        void Start()
        {
            player = FindObjectOfType<PlayerController>();  // Find player
            currentScene = SceneManager.GetActiveScene().name; // Get active scene name
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        IEnumerator FallingProcedure()
        {
            // Wait 1.5 secs then re load the scene
            yield return new WaitForSeconds(1.5f);
            LoadScene(currentScene);
        }

        public IEnumerator Victory()
        {
            yield return new WaitForSeconds(4f);
            completeLevelUI.SetActive(true);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        /// <param name="sceneName">The name of the scene to load</param>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

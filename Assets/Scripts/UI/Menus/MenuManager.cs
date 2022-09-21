using SideScrollControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;

        bool isPaused;

        private void Start()
        {
            pauseMenu.SetActive(false);
        }

        public void PauseGame()
        {
            if (isPaused)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                FindObjectOfType<PlayerSideScrollControls>().ChangeMoveStatus(true);
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                FindObjectOfType<PlayerSideScrollControls>().ChangeMoveStatus(false);
            }
        }

        public void Reset()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
            //save game first
            Application.Quit();
        }

        //need restart level
    }
}

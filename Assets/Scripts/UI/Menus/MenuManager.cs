using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                isPaused = !isPaused;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                isPaused = !isPaused;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        public void QuitGame()
        {
            //save game first
            Application.Quit();
        }

        //need restart level
    }
}

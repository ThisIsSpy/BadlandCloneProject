using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        private PlayerController controller;
        private PlayerView view;
        private SceneManager sceneManager;
        private bool isPlayerDead;

        private void Update()
        {
            if (!isPlayerDead)
            {
                ListenForFlyInput();
                ListenForMoveInput();
            }
            else if (isPlayerDead)
            {
                ListenForRestartInput();
            }
        }
        private void ListenForFlyInput()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                controller.InvokeFly();
            }
        }
        private void ListenForMoveInput()
        {
            controller.InvokeMove();
        }
        private void ListenForRestartInput()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                sceneManager.LoadScene();
            }
        }
        private void OnDeath()
        {
            isPlayerDead = true;
        }
        public void Construct(PlayerController controller, PlayerView view, SceneManager sceneManager)
        {
            this.controller = controller;
            this.view = view;
            this.sceneManager = sceneManager;
            isPlayerDead = false;
            view.OnDeath += OnDeath;
        }
    }
}

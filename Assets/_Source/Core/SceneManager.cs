using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneManager : MonoBehaviour
    {
        private PlayerView view;
        public void LoadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
        public void Construct(PlayerView view)
        {
            this.view = view;
            view.OnReachFinish += LoadScene;
        }
    }
}

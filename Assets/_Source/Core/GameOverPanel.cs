using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class GameOverPanel : MonoBehaviour
    {
        private PlayerView view;

        public void Construct(PlayerView view)
        {
            this.view = view;
            view.OnDeath += ShowPanel;
            this.gameObject.SetActive(false);
        }
        private void ShowPanel()
        {
            this.gameObject.SetActive(true);
        }
    }
}

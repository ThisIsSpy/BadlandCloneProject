using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerView view;
        private PlayerModel model;
        public void InvokeFly()
        {
            view.Fly(model.FlyingSpeed);
        }
        public void InvokeMove()
        {
            view.Move(model.MovingSpeed);
        }
        private void InvokeDeath()
        {
            Destroy(gameObject);
        }

        public void Construct(PlayerView view, PlayerModel model)
        {
            this.view = view;
            this.model = model;
            view.OnDeath += InvokeDeath;
        }
    }
}

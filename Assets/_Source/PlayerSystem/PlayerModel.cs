using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerModel
    {
        private float _flyingSpeed;
        private float _movingSpeed;
        
        public PlayerModel(float flyingSpeed, float movingSpeed)
        {
            FlyingSpeed = flyingSpeed;
            MovingSpeed = movingSpeed;
        }

        public float FlyingSpeed
        {
            get { return _flyingSpeed; }
            set { _flyingSpeed = value; }
        }
        public float MovingSpeed
        {
            get { return _movingSpeed; }
            set { _movingSpeed = value; }
        }
    }
}

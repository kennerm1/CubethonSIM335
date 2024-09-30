using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class Shake : Observer
    {
        private bool shakeyShakey = false;
        private Score score;

        void Update()
        {
            if (shakeyShakey == true)
            {
                score.Shakey();
            }
        }

        public override void Notify(Subject subject)
        {
            if (!score)
            {
                score = subject.GetComponent<Score>();
            }
            if (score)
            {
                shakeyShakey = score.ShakeyScore;
            }
        }
    }
}
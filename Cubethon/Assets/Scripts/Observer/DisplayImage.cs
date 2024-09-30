using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class DisplayImage : Observer
    {
        public bool isBlocked;
        public bool isPopped;
        private Score score;

        void Update()
        {
            if (isBlocked == true)
            {
                score.Cat();
            }
            if (isPopped == true)
            {
                score.Celeb();
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
                isPopped = score.celebScore;
                isBlocked = score.catScore;
            }
        }
    }
}
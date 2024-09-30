using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Chapter.Observer
{
    public class Score : Subject
    {
        public Transform player;
        public TMP_Text scoreText;
        private Shake shake;
        public Camera cam;
        private DisplayImage ui;
        public Vector3 offset;
        public Vector3 _initialPosition;
        public Quaternion _initialRotation;
        public float rotationSpeed = 20f;

        public bool shakey = false;
        public bool ShakeyScore;
        public bool celebScore;
        public bool catScore;

        public GameObject celebImage;
        public GameObject catPNG;

        void Awake()
        {
            shake = gameObject.AddComponent<Shake>();
            ui = gameObject.AddComponent<DisplayImage>();
        }

        void OnEnable()
        {
            if (shake)
                Attach(shake);
            if (ui)
                Attach(ui);

            _initialPosition = gameObject.transform.localPosition;
        }

        void OnDisable()
        {
            if (shake)
                Detach(shake);
            if (ui)
                Detach(ui);
        }

        void Update()
        {
            scoreText.text = player.position.z.ToString("0");

            if (player.position.z >= 150)
            {
                ShakeyScore = true;
                NotifyObservers();
            }

            if (player.position.z >= 100)
            {
                celebScore = true;
                NotifyObservers();
            }

            if (player.position.z >= 250)
            {
                catScore = true;
                NotifyObservers();
            }
        }

        public void Shakey()
        {
            if (ShakeyScore && !shake)
            {
                Vector3 newPosition = player.position + player.forward * 10.7f;
                cam.transform.position = newPosition;
                cam.transform.LookAt(player.position);
            }
        }

        public void Celeb()
        {
            celebImage.SetActive(true);
        }

        public void Cat()
        {
            catPNG.SetActive(true);
            celebImage.SetActive(false);
        }
    }

}

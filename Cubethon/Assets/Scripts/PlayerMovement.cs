using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Chapter.Command
{
    public class PlayerMovement : MonoBehaviour
    {
        private Invoker _invoker;
        public Rigidbody rb;
        public float forwardForce = 2000;
        public float sidewaysForce = 500;
        private bool _isReplaying;
        private bool _isRecording;
        private Command _buttonA, _buttonD;

        void Update()
        {
            if (!_isReplaying && _isRecording)
            {
                if (Input.GetKeyUp(KeyCode.A))
                    _invoker.ExecuteCommand(_buttonA);

                if (Input.GetKeyUp(KeyCode.D))
                    _invoker.ExecuteCommand(_buttonD);
            }
        }
        void FixedUpdate()
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (rb.position.y < -1f)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }

        void OnGUI()
        {
            if (GUILayout.Button("Start Recording"))
            {
                _isReplaying = false;
                _isRecording = true;
                _invoker.Record();
            }

            if (GUILayout.Button("Stop Recording"))
            {
                _isRecording = false;
            }

            if (!_isRecording)
            {
                if (GUILayout.Button("Start Replay"))
                {
                    _isRecording = false;
                    _isReplaying = true;
                    _invoker.Replay();
                }
            }
        }
    }
}


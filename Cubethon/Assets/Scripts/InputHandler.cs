/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Command
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker _invoker;
        private bool _isReplaying;
        private bool _isRecording;
        private PlayerMovement _bikeController;
        private Command _buttonA, _buttonD;

        void Start()
        {
            _invoker = gameObject.AddComponent<Invoker>();
            _bikeController = FindObjectOfType<PlayerMovement>();

            _buttonA = new PlayerMovement(_bikeController);
            _buttonD = new PlayerMovement(_bikeController);
        }

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
}*/
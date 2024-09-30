using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject completeLevelUI;
    bool instantReplay = false;
    GameObject player;
    float replayStartTime;

    private void OnEnable()
    {
        PlayerCollision.OnHitObstacle += EndGame;
    }

    private void OnDisable()
    {
        PlayerCollision.OnHitObstacle -= EndGame;
    }

    void Start()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.gameObject;

        if (CommandLog.commands.Count > 0)
        {
            instantReplay = true;
            replayStartTime = Time.timeSinceLevelLoad;
        }
    }

    void FixedUpdate()
    {
        if (instantReplay)
        {
            RunInstantReplay();
        }
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame(Collision collisionInfo)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        PlayerCollision.OnHitObstacle -= EndGame;

        if (collisionInfo != null)
        {
            Debug.Log("Hit: " + collisionInfo.collider.name);
        }

        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart", 2f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void RunInstantReplay()
    {

        if (CommandLog.commands.Count == 0)
        {
            return;
        }

        Command command = CommandLog.commands.Peek();
        if (Time.timeSinceLevelLoad >= command.timestamp)
        {
            command = CommandLog.commands.Dequeue();
            command._player = player.GetComponent<Rigidbody>();
            Invoker invoker = new Invoker();
            Debug.Log("Replay!");

            invoker.disableLog = true;
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator anim;

    public GameObject game;
    public GameObject obstacleSpawner;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool gamePlaying = game.GetComponent<GameController>().gameState == GameState.Playing;

        if(gamePlaying && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            UpdateState("Dinosaurio_Jump");
        }
    }

    public void UpdateState(string state = null)
    {
        if(state != null)
        {
            anim.Play(state);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            UpdateState("Dinosaurio_Death");
            game.GetComponent<GameController>().gameState = GameState.Ended;
            obstacleSpawner.SendMessage("StopSpawn", true);
            game.SendMessage("StopScore", true);
            game.GetComponent<Parallax>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject monkey, obstacleSpawner;
    public MonkeyMover player;
    public ObstacleSpawner spawner;
    public Animator countdown;
    void Start()
    {
        player = monkey.GetComponent<MonkeyMover>();
        spawner = obstacleSpawner.GetComponent<ObstacleSpawner>();
        StartMonkey();
    }
    
    void StartMonkey()
    {
        if (player.isReady)
        {
            countdown.Play("Countdowner");
            player.isReady = false;
        }
    }

    public void NextLevel()
    {
        player.RandomiseRampDistance();
        spawner.AddNewObstacle();
        //countdown.Play("Countdowner");
    }

    public void RetryLevel()
    {
        countdown.Play("Countdowner");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonkeyMover : MonoBehaviour
{
    public float[] speeds;
    public float[] rampUps;
    public bool ReadyToMove;
    public float moveSpeed, rampDistance;
    public float Distance;
    private Rigidbody rb;
    public Animator anim;
    public GameManager gm;

    public ParticleSystem conf1, conf2;

    public bool isReady,reachedFinish;

    // Start is called before the first frame update
    private void OnEnable()
    {
        isReady = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RandomizeAndSave();
    }

    void RandomizeAndSave()
    {
        float s = Random.Range(1, 15);
        while (speeds.Contains(s))
        {
            s = Random.Range(1, 10);
        }
        moveSpeed = s;
        RandomiseRampDistance();

    }

    public void RandomiseRampDistance()
    {
        float r = Random.Range(1, 10);
        while (rampUps.Contains(r))
        {
            r = Random.Range(1, 10);
        }
        rampDistance = -r;
        transform.position = new Vector3(transform.position.x, transform.position.y, rampDistance);
    }

    public void HasStopped()
    {
        if (rb.velocity.magnitude <= 0.05f)
        {
            rb.velocity = Vector3.zero;
        }

        if (reachedFinish)
        {
            gm.NextLevel();
        }
        else
        {
            gm.RetryLevel();
        }
    }
    
    void MoveMonkey()
    {
        rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Finish")
        {
            reachedFinish = true;
            ReadyToMove = false;
            conf1.Play();
            conf2.Play();
        }

        if (other.gameObject.tag == "Obstacle")
        {
            ReadyToMove = false;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Ramp Up":
                ReadyToMove = false;
                break; 
        }    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (ReadyToMove)
        {
            MoveMonkey();
        }
        else
        {
            HasStopped();
        }
    }

    public void RetryLevel()
    {
    RandomiseRampDistance();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOActionKin : ScriptableObject,UFOAction
{
    public Director director;
    public GameObject player;
    Vector3 start;
    Vector3 end;
    public int speed = 3;
    public bool ifRun = true;
    public void SetSpeed(int speed)
    {
        this.speed = speed;
    }
    public void SetIfRun(bool signal)
    {
        this.ifRun = signal;
    }
    public GameObject GetPlayer()
    {
        return this.player;
    }
    public void SetPlayer(GameObject g)
    {
        this.player = g;
    }
    public void Start()
    {
        director = Director.GetInstance();
        start = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0);
        if (start.x < 10 && start.x > -10)
            start.x *= 4;
        if (start.y < 10 && start.y > -10)
            start.y *= 4;
        end = new Vector3(-start.x, -start.y, 0);
        player.transform.position = start;
        SetColor();
        Rigidbody rigid = player.GetComponent<Rigidbody>();
        if(rigid != null)
        {
            Destroy(rigid);
        }
    }

    public void Update()
    {
        if (ifRun)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position,
                end, speed * Time.deltaTime);
            if (player.transform.position == end)
            {
                this.director.currentController.ufofactory.Not_hit(this.player);
            }
        }
    }

    public void SetColor()
    {
        int color = Random.Range(1, 4);
        switch (color)
        {
            case 1:
                player.GetComponent<MeshRenderer>().material.color = Color.red;
                foreach (Transform child in player.transform)
                {
                    child.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                break;
            case 2:
                player.GetComponent<MeshRenderer>().material.color = Color.green;
                foreach (Transform child in player.transform)
                {
                    child.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                }
                break;
            case 3:
                player.GetComponent<MeshRenderer>().material.color = Color.grey;
                foreach (Transform child in player.transform)
                {
                    child.gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
                }
                break;
            default:
                break;
        }
    }
}

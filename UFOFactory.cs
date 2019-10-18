using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFactory : MonoBehaviour
{
    public int sign = 0;
    public List<GameObject> onuse;
    public List<GameObject> nouse;
    public List<UFOActionKin> kinactions;
    public List<UFOActiondo> doactions;
    public List<UFOAction> ufoactions;
    public int round = 0;
    public int score = 0;
    private void Start()
    {
        onuse = new List<GameObject>();
        nouse = new List<GameObject>();
        kinactions = new List<UFOActionKin>();
        doactions = new List<UFOActiondo>();
        ufoactions = new List<UFOAction>();
        for(int i = 0; i < 10; i++)
        {
            nouse.Add(Object.Instantiate(Resources.Load("prefabs/UFO",
                typeof(GameObject)), new Vector3(0, -20, 0), Quaternion.identity,
                null) as GameObject);
            doactions.Add(ScriptableObject.CreateInstance<UFOActiondo>());
            kinactions.Add(ScriptableObject.CreateInstance<UFOActionKin>());
        }
        if (sign == 1)
        {
            for(int i = 0; i < 10; i++)
            {
                ufoactions.Add(doactions[i]);
            }
        }
        else
        {
            for(int i = 0; i < 10; i++)
            {
                ufoactions.Add(kinactions[i]);
            }
        }
        for(int i = 0; i < 10; i++)
        {
            ufoactions[i].SetPlayer(nouse[i]);
            ufoactions[i].Start();
        }
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        if (round <= 10)
        {
            for(int i = 0; i < 10; i++)
            {
                ufoactions[i].Update();
            }
            if (nouse.Count == 10)
            {
                round += 1;
                if (round <= 10)
                {
                    Get_ready(round);
                }
            }
            
        }
    }

    public void Hitted(GameObject g)
    {
        if (round <= 10)
        {
            if (g.gameObject.GetComponent<MeshRenderer>().material.color == Color.red)
                score += 3;
            else if (g.gameObject.GetComponent<MeshRenderer>().material.color == Color.green)
                score += 2;
            else if (g.gameObject.GetComponent<MeshRenderer>().material.color == Color.gray)
                score++;
        }
        this.onuse.Remove(g);
        g.transform.position = new Vector3(0, -20, 0);
        for(int i =0; i < 10; i++)
        {
            if (ufoactions[i].GetPlayer() == g)
            {
                ufoactions[i].SetIfRun(false);
                Rigidbody rigid = ufoactions[i].GetPlayer().GetComponent<Rigidbody>();
                if(rigid != null)
                {
                    rigid.velocity = Vector3.zero;
                }
            }
        }
        this.nouse.Add(g);
    }

    public void Not_hit(GameObject g)
    {
        this.onuse.Remove(g);
        g.transform.position = new Vector3(0, -20, 0);
        for(int i = 0; i < 10; i++)
        {
            if (ufoactions[i].GetPlayer() == g)
            {
                ufoactions[i].SetIfRun(false);
                Rigidbody rigid = ufoactions[i].GetPlayer().GetComponent<Rigidbody>();
                if (rigid != null)
                {
                    rigid.velocity = Vector3.zero;
                }
            }
        }
        this.nouse.Add(g);
    }

    public void Get_ready(int round)
    {
        for(int i=0;i<10; i++)
        {
            onuse.Add(nouse[0]);
            nouse.Remove(nouse[0]);
            ufoactions[i].SetSpeed(round + 2);
            ufoactions[i].Start();
            ufoactions[i].SetIfRun(true);
        }
    }
}

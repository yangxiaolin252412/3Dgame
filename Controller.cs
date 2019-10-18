using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public UFOFactory ufofactory;
    public Director director;
    private GameObject myufofactory;
    void Awake()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        myufofactory = new GameObject("Disk_Factory");
        myufofactory.AddComponent<UFOFactory>();
        director = Director.GetInstance();
        ufofactory = Singleton<UFOFactory>.Instance;
        director.currentController = this;
        ufofactory.enabled = false;
    }
}

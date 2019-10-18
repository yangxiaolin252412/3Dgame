using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UFOAction 
{
    // Start is called before the first frame update
    void Start();
    void SetSpeed(int speed);
    void SetIfRun(bool signal);
    GameObject GetPlayer();
    void SetPlayer(GameObject g);
    void Update();
}

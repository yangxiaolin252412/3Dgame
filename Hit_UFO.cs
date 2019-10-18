using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_UFO : MonoBehaviour
{
    public GameObject cam;
    public Director director;
    // Start is called before the first frame update
    private void Start()
    {
        director = Director.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mp = Input.mousePosition;
            Camera ca;
            if (cam != null)
                ca = cam.GetComponent<Camera>();
            else
                ca = Camera.main;

            Ray ray = ca.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                director.currentController.ufofactory.Hitted(hit.transform.gameObject);
            }
        }
    }
}

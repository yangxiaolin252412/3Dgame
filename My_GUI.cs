using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class My_GUI : MonoBehaviour
{
    public Director director;
    bool wel = true;

    // Start is called before the first frame update
    void Start()
    {
        director = Director.GetInstance();
    }

    
    private void OnGUI()
    {
        if (wel)
        {
            if(GUI.Button(new Rect(0.4f * Screen.width, 70, 150, 35), "运动"))
            {
                wel = false;
                director.currentController.ufofactory.sign = 0;
                director.currentController.ufofactory.enabled = true;
            }
            if (GUI.Button(new Rect(0.4f * Screen.width, 130, 150, 35), "动力"))
            {
                wel = false;
                director.currentController.ufofactory.sign = 1;
                director.currentController.ufofactory.enabled = true;
            }
        }
        int my_round = director.currentController.ufofactory.round;
        if(my_round== 11)
        {
            int final_score = director.currentController.ufofactory.score;
            GUIStyle ending = new GUIStyle();
            ending.normal.background = null;
            ending.normal.textColor = new Color(255, 255, 255);
            ending.fontSize = 90;
            string ending_score = "Final Score:" + final_score.ToString();
            GUI.Label(new Rect(0.13f*Screen.width, 0.4f * Screen.height, 300, 300), ending_score, ending);
            if(GUI.Button(new Rect(0.7f * Screen.width, 0.7f * Screen.height, 150, 35), "restart"))
            {
                EditorSceneManager.LoadScene(0);
            }
        }
        else
        {
            string round = my_round.ToString();
            round = "Round: " + round;
            GUIStyle guis = new GUIStyle();
            guis.normal.background = null;
            guis.normal.textColor = new Color(255, 255, 255);
            guis.fontSize = 30;
            GUI.Label(new Rect(0.8f * Screen.width, 240, 150, 35), round, guis);
            string score = director.currentController.ufofactory.score.ToString();
            score = "Score: " + score;
            GUI.Label(new Rect(0.8f * Screen.width, 270, 150, 35), score, guis);
        }
    }
}

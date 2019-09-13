using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private string[] flag = new string[9];
    private int[] set = new int[9];
    private int turn = 0;
    private string result = "";



    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    void init()
    {
        for (int i = 0; i < 9; i++)
        {
            flag[i] = "";
            set[i] = 0;
        }
        turn = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.Label(new Rect(40, 320, 50, 50), result);
        if (GUI.Button(new Rect(200, 320, 100, 40), "restart"))
        {
            init();
            result = "";
        }
        GUI.color = Color.yellow;
        GUI.backgroundColor = Color.black;
        int x = 20;
        int y = 20;
        int num = 0;
        if (isend())
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GUI.Button(new Rect(x, y, 80, 80), flag[num]);

                    x += 80;
                    num++;
                }
                y += 80;
                x = 20;
            }
            if (GUI.Button(new Rect(200, 320, 100, 40), "restart"))
            {
                init();
                result = "";
            }
            return;
        }
        x = 20;
        y = 20;
        num = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (GUI.Button(new Rect(x, y, 80, 80), flag[num]))
                {
                    if (set[num] == 0 && turn == 0)
                    {
                        flag[num] = "O";
                        set[num] = 2;
                    }
                    else if (set[num] == 0 && turn == 1)
                    {
                        flag[num] = "X";
                        set[num] = 1;
                    }
                    if (turn == 0)
                    {
                        turn = 1;
                    }
                    else if (turn == 1)
                    {
                        turn = 0;
                    }
                }
                x += 80;
                num++;
            }
            y += 80;
            x = 20;
        }
    }

    bool isend()
    {
        int j = 0;
        for (j = 0; j < 7; j += 3)
        {
            if (set[j] == set[j + 1] && set[j +1] == set[j + 2])
            {
                if (set[j] == 1)
                {
                    result = "X wins by row";
                    return true;
                }
                else if (set[j] == 2)
                {
                    result = "O wins by row";
                    return true;
                }
            }
        }

        for (j = 0; j < 3; j++)
        {
            if (set[j] == set[j + 3] && set[j + 3] == set[j + 6])
            {
                if (set[j] == 1)
                {
                    result = "X wins by column";
                    return true;
                }
                else if (set[j] == 2)
                {
                    result = "O wins by column";
                    return true;
                }
            }
        }

        if (set[0] == set[4] && set[4] == set[8])
        {
            if (set[0] == 1)
            {
                result = "X wins by diagonal";
                return true;
            }
            else if (set[0] == 2)
            {
                result = "O wins by diagonal";
                return true;
            }
        }
        if (set[2] == set[4] && set[4] == set[6])
        {
            if (set[2] == 1)
            {
                result = "X wins by diagonal";
                return true;
            }
            else if (set[2] == 2)
            {
                result = "O wins by diagonal";
                return true;
            }
        }
        int sign = 0;
        for (int i = 0; i < 9; i++)
        {
            if (set[i] == 0)
            {
                sign = 1;
                break;
            }
        }
        if (sign == 0)
        {
            result = "a sraw";
            return true;
        }
        return false;
    }
}

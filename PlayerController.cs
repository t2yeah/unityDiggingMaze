using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public void Position(int x,int y)
    {
        Debug.Log("your Position is "+StageInit.maze[x,y]);
    }
}



public class PlayerController : MonoBehaviour
{
    Player myPlayer = new Player();

    void Update()
    {
        //for (int i = 0; i < StageInit.maze.GetLength(0); i++)
        //{
        //    for (int j = 0; j < StageInit.maze.GetLength(1); j++)
        //    {
        //        myPlayer.Position(i, j);
        //    }
        //}



    }
}


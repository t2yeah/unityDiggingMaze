using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInit : MonoBehaviour
{
    public static int mazeWidth = 49;
    public static int mazeHight = 45;

    int diggerPosX = 25;
    int diggerPosY = 25;

    internal static GameObject[,] maze = new GameObject[mazeWidth, mazeHight];
    //internal static int[,] maze = new int[mazeWidth, mazeHight];  // test by 'int' type
    public GameObject blockPrefab;
    public GameObject mazeObj;

    // Start is called before the first frame update
    void Start()
    {
        // difine 'maze' array
        // draw maze filled with 'Block's
        for (int i = 0; i < mazeWidth; i++)
        {
            for (int j = 0; j < mazeHight; j++)
            {
                maze[i, j] = Instantiate(blockPrefab, mazeObj.transform);
                maze[i, j].transform.position = new Vector3(1f * i, 0.5f, 1f * j);
                //maze[i, j] = i*10+j;// test by 'int' type
                if (i == 0 || j == 0 || i == mazeWidth - 1 || j == mazeHight - 1|| i == 1 || j == 1 || i == mazeWidth - 2 || j == mazeHight - 2)
                {
                    maze[i, j].SetActive(false);
                }
            }
        }
        // dig start position
        maze[diggerPosX, diggerPosY].SetActive(false);

    }

    int researchX;
    int researchY;


    bool[] availDirection = new bool[4];

    int[] digLog = new int[100*100];
    int n = 0;// number of steps

    // Update is called once per frame
    void Update()
    {
        researchX = diggerPosX;
        researchY = diggerPosY;

        //is available Direction exist?
        availDirection[0] = maze[researchX, researchY + 2].activeSelf;//Up
        availDirection[1] = maze[researchX + 2, researchY].activeSelf;//Right
        availDirection[2] = maze[researchX, researchY - 2].activeSelf;//Down
        availDirection[3] = maze[researchX - 2, researchY].activeSelf;//Left

        //no availDirection

        if (!(availDirection[0]|availDirection[1]|availDirection[2]|availDirection[3]) & n > 0)
        {
            n -= 1;
            diggerPosX = digLog[n] / 100;
            diggerPosY = digLog[n] % 100;
        }


        //Decide dig Direction (0,+1):UP=0 (+1,0):RIGHT=1 (0,-1):Down=2 (-1,0):LEFT=3
        int diggerDirection = Random.Range(0, 4);

        if (availDirection[diggerDirection])
        {
            int diggerUpDown = 0;
            int diggerRightLeft = 0;

            switch (diggerDirection)
            {
                case 0:
                    diggerUpDown = 1;
                    break;
                case 1:
                    diggerRightLeft = 1;
                    break;
                case 2:
                    diggerUpDown = -1;
                    break;
                default:
                    diggerRightLeft = -1;
                    break;
            }

            maze[diggerPosX + diggerRightLeft, diggerPosY + diggerUpDown].SetActive(false);
            maze[diggerPosX + diggerRightLeft * 2, diggerPosY + diggerUpDown * 2].SetActive(false);

            diggerPosX += diggerRightLeft * 2;
            diggerPosY += diggerUpDown * 2;

            digLog[n] = diggerPosX * 100 + diggerPosY;
            Debug.Log(digLog[n]);
            n += 1;


        }



    }
}



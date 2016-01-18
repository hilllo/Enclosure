using UnityEngine;
using System.Collections;

public class Player : MovingObject
{
    int id;
    int currentX;
    int currentY;
    int land = 0;
    bool turn = false;

    public void SetPlayer(int playerID, int x, int y)
    {
        id = playerID;
        currentX = x;
        currentY = y;
    }

    public void isTurn()
    {
        if (!turn)
        {
            Debug.Log(this.gameObject.name + "'s turn.");
            turn = true;
            StartCoroutine(PlayerOperator());
        }
        
    }

    IEnumerator PlayerOperator() //operator of player
    {
        int xDir = 0;
        int yDir = 0;
        bool canMove;
        Debug.Log("Waiting for input..");

        while (turn)
        {
            //operator sets
            if (id == 1)
            {
                if (Input.GetKeyDown("w")) yDir = 1;
                else if (Input.GetKeyDown("d")) xDir = 1;
                else if (Input.GetKeyDown("a")) xDir = -1;

            }

            else if (id == 2)
            {
                if (Input.GetKeyDown("down")) yDir = -1;
                else if (Input.GetKeyDown("left")) xDir = -1;
                else if (Input.GetKeyDown("right")) xDir = 1;
            }

            //if (Input.GetKeyDown("right")) xDir = 1;
            //else if (Input.GetKeyDown("up")) yDir = 1;
            //if (Input.GetKeyDown("left")) xDir = -1;
            //else if (Input.GetKeyDown("down")) yDir = -1;

            //if ((id == 1 && yDir == -1)|| (id == 2 && yDir == 1)) yDir = 0;

            Debug.Log(id + " Get input (" + xDir + "," + yDir + ")");

            if (xDir != 0 || yDir != 0)
            {
                Debug.Log("Goto (" + xDir + "," + yDir + ")");
                canMove = gameObject.GetComponent<Player>().Move(xDir, yDir);
                if (canMove)
                {
                    turn = false;
                    Debug.Log("End Coroutine");
                    yield return null;
                }
                else
                {
                    xDir = 0;
                    yDir = 0;
                    Debug.Log("Cannot move to this grid.");
                }
            }
            Debug.Log("No key input.");
            yield return null;
        }

    }


    // Use this for initialization

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update () {

    }
}

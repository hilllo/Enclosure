using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float moveTime = 0.1f;
    public LayerMask blockingLayer;

    BoxCollider2D boxCollider;
    Rigidbody2D rb2D;
    float inverseMoveTime;

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
        Debug.Log(this.gameObject.name + "'s turn.");
;        turn = true;
        StartCoroutine(PlayerOperator());
    }

    IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude; //compare distance in rest
        while (sqrRemainingDistance > float.Epsilon) // float.Epsilon =/= 0
        {
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
    }

    public bool Move(int xDir, int yDir)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
        RaycastHit2D hit;

        Debug.Log("Moving(): " + gameObject.name + " boxCollider = " + boxCollider.isActiveAndEnabled);

        boxCollider.enabled = false; // avoiding colliding himself
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }
        else
        {
            //sfx_Error
            return false;
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
    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
    }
	
	// Update is called once per frame
	void Update () {

    }
}

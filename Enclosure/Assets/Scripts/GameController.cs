using UnityEngine;
using System.Collections;
using System.Collections.Generic; //for List

public class GameController : Singleton<GameController>
{
    public GameObject[] playerGOPrefab;
    GameObject[] playerGO = new GameObject[2];
    int level = 1;
    bool gameOver = false;
    bool turnLock = false;


    GameObject InitPlayer(GameObject go, int id, int x, int y)
    {
        GameObject instance = Instantiate(go, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        Debug.Log("Instantiated " + instance.name);
        instance.GetComponent<Player>().SetPlayer(id,x, y);
        return instance;
    }

    void InitGame()
    {
        BoardManager.Instance.SetupScence(level);
        CameraController.Instance.InitCamera();
        playerGO[0] = InitPlayer(playerGOPrefab[0], 1, 0, 0);
        playerGO[1] = InitPlayer(playerGOPrefab[1], 2, BoardManager.Instance.GetColumns() - 1, BoardManager.Instance.GetRows() - 1);

    }

    // Use this for initialization

    void Start () {
        InitGame();
        //StartCoroutine(CoRoutinePlayerControl(0));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1)) playerGO[0].GetComponent<Player>().isTurn();
        if (Input.GetKeyDown(KeyCode.Alpha2)) playerGO[1].GetComponent<Player>().isTurn();



        if (Input.GetKeyDown("right"))
        {
            Debug.Log("Get key RIGHT down");
        }
        else if (Input.GetKeyDown("left"))
        {
            Debug.Log("Get key LEFT down");
        }
        else if (Input.GetKeyDown("up"))
        {
            Debug.Log("Get key UP down");
        }
        else if (Input.GetKeyDown("down"))
        {
            Debug.Log("Get key DOWN down");
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic; //for List

public class GameController : Singleton<GameController>
{
    public GameObject Player1GO;
    public GameObject Player2GO;
    int level = 1;
    Transform mainCameraTransform;
    void InitPlayer(GameObject go, int x, int y)
    {
        GameObject intance = Instantiate(go, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        intance.GetComponent<Player>().SetPlayerPosition(x, y);
    }

    void InitGame()
    {
        BoardManager.Instance.SetupScence(level);
        CameraController.Instance.InitCamera();
        InitPlayer(Player1GO, 0, 0);
        InitPlayer(Player2GO, BoardManager.Instance.GetColumns()-1, BoardManager.Instance.GetRows()-1);
    }

	// Use this for initialization

	void Start () {
        InitGame();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

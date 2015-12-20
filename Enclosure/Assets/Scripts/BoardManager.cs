using UnityEngine;
using System.Collections;
using System; // for serialisable: saving objects as char, letting them being able to transfer through internet
using System.Collections.Generic; //for List
using Random = UnityEngine.Random;

[Serializable]
public class Count
{
    public int minimum;
    public int maximum;
    public Count(int min, int max)
    {
        minimum = min;
        maximum = max;
    }
}

public class BoardManager : Singleton<BoardManager>
{
    

    public GameObject[] landTiles;
    public GameObject[] fenceTiles;
    public GameObject[] player1LandTiles;
    public GameObject[] player2LandTiles;

    int columns; //playableGround + 1
    int rows;
    int bomb;
    public Transform boardHolder;
    List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();
        for(int x = 1; x < columns-1; x++)
        {
            for(int y = 1; y < rows-1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }
    
    void BoardSetup()
    {
        Destroy(boardHolder.gameObject);
        //Debug.Log("Destory boardHolder");
        boardHolder = new GameObject("Board").transform;
        //Debug.Log("Build new boardHolder");

        for(int x = -1; x < columns + 1; x++)
        {
            for(int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = landTiles[Random.Range(0, landTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = fenceTiles[Random.Range(0, fenceTiles.Length)];
                }
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    void LevelSetup(int level)
    {
        switch (level)
        {
            case 1:
                columns = 11;
                rows = 11;
                break;
            default:
                break;
        }
    }

    public int GetColumns()
    {
        return columns;
    }

    public int GetRows()
    {
        return rows;
    }

    public void FenceSet()
    {

    }

    public void SetupScence(int level)
    {
        LevelSetup(level);
        BoardSetup();
        InitialiseList();
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}

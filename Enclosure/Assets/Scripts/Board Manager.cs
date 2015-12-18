using UnityEngine;
using System.Collections;
using System;   //for Serialisable - save object as char (in order to transfer through net)
using System.Collections.Generic;   // for List
using Random = UnityEngine.Random;

[Serializable]
public class Count
{
    public int minimum;
    public int maximum;
    public Count(int min, int max)
    {
        this.minimum = min;
        this.maximum = max;
    }
}


public class BoardManager : MonoBehaviour {
    public int columns = 10;
    public int rows = 10;
    //public Count wallCount = new Count(5,9);

    public GameObject[] floorTiles;
    public GameObject[] player1LandTiles;
    public GameObject[] player2LandTiles;

    Transform boardHolder;
    List<Vector3> gridPositions = new List<Vector3>;

    void InitialiseList()
    {
        gridPositions.Clear();
        for(int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; x < rows - 1; x++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

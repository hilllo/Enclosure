using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    int currentX;
    int currentY;
    int land = 0;

    public void SetPlayerPosition(int x, int y)
    {
        currentX = x;
        currentY = y;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

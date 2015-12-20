using UnityEngine;
using System.Collections;

public class CameraController : Singleton<CameraController>
{
    Transform cameraTransform;
	// Use this for initialization
    void Awake()
    {
        cameraTransform = GetComponent<Transform>();
    }

    public void InitCamera()
    {
        cameraTransform.position = new Vector3(Mathf.Abs(BoardManager.Instance.GetColumns() / 2), Mathf.Abs(BoardManager.Instance.GetRows() / 2), cameraTransform.position.z);
    }

	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

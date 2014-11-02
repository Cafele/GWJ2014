using UnityEngine;
using System.Collections;

public class rotateController : MonoBehaviour {

    public float speed = 1f;
    public bool stop = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (stop)
            return;
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}
}

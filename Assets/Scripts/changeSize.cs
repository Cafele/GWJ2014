using UnityEngine;
using System.Collections;

public class changeSize : MonoBehaviour {
    public float speed = 1f;
    int dir = 1;
    Vector3 var = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        var = transform.localScale;
        if (var.x < 0f)
        {
            dir = 1;
            speed = 0.5f;
        }
        else if (var.x > 1f)
        {
            dir = -1;
            speed = 4f;
        }
        var.x += Time.deltaTime * speed * dir;
        transform.localScale = var;
	}
}

using UnityEngine;
using System.Collections;

public class goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            Debug.Log("ganaste");
            BoxCollider2D coll = GetComponent<BoxCollider2D>();
            coll.center = Vector2.zero;
            coll.isTrigger = false;
        }
    }
}

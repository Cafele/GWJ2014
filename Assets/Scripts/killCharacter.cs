using UnityEngine;
using System.Collections;

public class killCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D obj)
    {
        //si toca al player lo mata
        if (obj.gameObject.tag == "Player")
        {
            //Debug.Log("muerto");
            Destroy(obj.transform.root.gameObject);
           
        }
    }
}

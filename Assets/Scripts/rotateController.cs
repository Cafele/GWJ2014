using UnityEngine;
using System.Collections;

public class rotateController : MonoBehaviour {
    public enum type
    {
        x,
        y,
        z
    }
    public type rotationType = type.z;
    public float speed = 1f;
    public bool stopInNomal = false;
    bool stop = false;
    public float timeToWait = 1f;
    float angle = 0f;
    Vector3 rotateVector = Vector3.zero;
    IEnumerator WaitToMove( float seconds)
    {
        stop = true;
        Vector3 var = transform.rotation.eulerAngles;
        switch (rotationType)
        {
            case type.x:
                var.x = 0f;
                break;
            case type.y:
                var.y = 0f;
                break;
            case type.z:
                var.z = 0f;
                break;
        }
        transform.rotation = Quaternion.Euler(var);
        yield return new WaitForSeconds(seconds);
        stop = false;
    }

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        Debug.Log(rotateVector);
        if (stop)
            return;
        transform.Rotate(rotateVector);

        switch (rotationType)
        {
            case type.x :
                angle = transform.rotation.eulerAngles.x;
                rotateVector = new Vector3(speed * Time.deltaTime, 0f, 0f);
                break;
            case type.y:
                angle = transform.rotation.eulerAngles.y;
                rotateVector = new Vector3(0f, speed * Time.deltaTime, 0f);
                break;
            case type.z:
                angle = transform.rotation.eulerAngles.z;
                rotateVector = new Vector3(0f, 0f, speed * Time.deltaTime);
                break;
        }
        

        if (stopInNomal && (angle < 1f || angle > 359f))
            StartCoroutine(WaitToMove(timeToWait));
    }


}

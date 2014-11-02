using UnityEngine;
using System.Collections;

public class barController : MonoBehaviour {
    public float maxValue;
    public float value;
    public Transform bar;
	// Use this for initialization
	void Start () {
        setValue(value);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setValue(float x)
    {
        value = (x>maxValue)? maxValue: x;
        Vector3 val = bar.localScale;
        val.x = value / maxValue;
        bar.localScale = val;
    }
}

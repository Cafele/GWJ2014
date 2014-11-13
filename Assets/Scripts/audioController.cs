using UnityEngine;
using System.Collections;

public class audioController : MonoBehaviour {
    public Transform pos;
    public float sliderWidth = 200f;
    Vector3 screenPos;
	// Use this for initialization
    audioManager audioMgr;
    public GUISkin skin;
	void Start () {
        audioMgr = audioManager.GetInstance();
        screenPos = Camera.main.WorldToScreenPoint(pos.position);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnGUI()
    {
        GUI.skin = skin;
        audioMgr.volume = GUI.HorizontalSlider(new Rect(screenPos.x - sliderWidth / 2, Screen.height - screenPos.y, sliderWidth, 15f), audioMgr.volume, 0.0F, 1f);
        audioMgr.updateVolume();
    }
}

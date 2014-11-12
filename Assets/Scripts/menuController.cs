using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {
    public Color mouseOverColor = Color.red;
    public float mouseOverScale = 1.2f;
    public Color normalColor = Color.white;
    public menuOption buttonType = menuOption.none;
    public AudioClip mouseClickSound;
    public Color mouseClickColor = Color.blue;
    public enum menuOption
    {
        Play,
        Control,
        Quit,
        none
    }
	// Use this for initialization
	void Start () {
        renderer.material.color = normalColor;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnMouseOver()
    {
       // renderer.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
        renderer.material.color = mouseOverColor;
        transform.localScale = Vector3.one * mouseOverScale;
        audio.Play();
    }
    void OnMouseExit()
    {
        // renderer.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
        renderer.material.color = normalColor;
        transform.localScale = Vector3.one;  
    }

    void OnMouseDown()
    {
        audio.PlayOneShot(mouseClickSound);
        switch(buttonType)
        {
            case menuOption.Control :
                // menu de pausa

                break;
            case menuOption.Play:
                Application.LoadLevel("level1");
                break;
            case menuOption.Quit:
                Application.Quit();
                break;
            default :
                break;
        }
    }
}

using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {
    public Color mouseOverColor = Color.red;
    public float mouseOverScale = 1.2f;
    public Color normalColor = Color.white;
    public menuOption buttonType = menuOption.none;
    
    public Color mouseClickColor = Color.blue;
    public Vector3 rotation = Vector3.zero;
    public bool rescale = true;
    public bool rotate = true;
    public GameObject mainMenu;
    public GameObject options;
    public GameObject GUICamera;
   // public float hSliderValue = 0f;
    audioManager audioMgr;
    public enum menuOption
    {
        Play,
        Control,
        Quit,
        MainMenu,
        Back,
        Resume,
        none
    }
	// Use this for initialization
	void Start () {
        renderer.material.color = normalColor;
        audioMgr = audioManager.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
        
            
	}
    void OnMouseEnter()
    {
       // renderer.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
        renderer.material.color = mouseOverColor;
        if(rescale)
        transform.localScale = Vector3.one * mouseOverScale;
        if(rotate)
        transform.rotation = Quaternion.Euler(rotation);
        audioMgr.playSound(sound.mouseOver);
    }
    void OnMouseExit()
    {
        //renderer.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
        renderer.material.color = normalColor;
        if(rotate)
        transform.rotation = Quaternion.Euler(Vector3.zero);
        if(rescale)
        transform.localScale = Vector3.one;  
    }

    void OnMouseDown()
    {
        renderer.material.color = normalColor;
        if (rotate)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        if (rescale)
            transform.localScale = Vector3.one;
        audioMgr.playSound(sound.click);
        switch(buttonType)
        {
            case menuOption.Control :
                // menu de pausa
                options.SetActive(true);
                mainMenu.SetActive(false);
                break;
            case menuOption.Play:
                Application.LoadLevel("level1");
                break;
            case menuOption.Quit:
                Application.Quit();
                break;
            case menuOption.Back:
                options.SetActive(false);
                mainMenu.SetActive(true);
                break;
            case menuOption.MainMenu :
                Application.LoadLevel("mainMenu");
                break;
            case menuOption.Resume :
                Time.timeScale = 1f;
                //transform.root.gameObject.SetActive(false);
                GUICamera.SetActive(false);
                break;
            default :
                break;
        }

    }

    
}

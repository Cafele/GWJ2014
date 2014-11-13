using UnityEngine;
using System.Collections;

public class graphicsController : MonoBehaviour {
    public Color colorSelected = Color.green;
    public Color mouseOverColor = Color.red;
    public Color normalColor = Color.white;
    audioManager audioMgr;
    public int level;
	// Use this for initialization
	void Start () {
        audioMgr = audioManager.GetInstance();
        if (level == QualitySettings.GetQualityLevel())
            renderer.material.color = colorSelected;
        
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnMouseEnter()
    {
        renderer.material.color = mouseOverColor;
        //audioMgr.playSound(sound.mouseOver);
    }
    void OnMouseExit()
    {
        renderer.material.color = (level == QualitySettings.GetQualityLevel()) ? colorSelected : normalColor;
        
    }

    void OnMouseDown()
    {
        transform.parent.FindChild(QualitySettings.names[QualitySettings.GetQualityLevel()]).renderer.material.color=normalColor;
        QualitySettings.SetQualityLevel(level);
        renderer.material.color = colorSelected;
        audioMgr.playSound(sound.click);
    }
}

using UnityEngine;
using System.Collections;
public enum sound
{
    click,
    mouseOver
}
public class audioManager : MonoBehaviour {

    private static audioManager instance;
    public float volume = 1f;
    public AudioClip[] Sounds;
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad( this.gameObject );
    }
    void Start()
    {
        volume = audio.volume;
    }
    public static audioManager GetInstance()
    {
        return instance;
    }

    public void playSound(sound index)
    {
        audio.PlayOneShot(Sounds[(int)index]);
    }

    public void updateVolume()
    {
        if (audio.volume != volume)
            audio.volume = volume;
    }
}

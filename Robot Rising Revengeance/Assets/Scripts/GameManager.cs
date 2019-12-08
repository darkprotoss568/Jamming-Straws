using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameEvent currentLinkedGameEvent;
    public ControlScript player;
    public HUDCanvas HUDScript;
    public AudioSource BGM;
    public AudioSource SoundEffects;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateEvent()
    {
        if (currentLinkedGameEvent != null)
        {
            currentLinkedGameEvent.Activate();
        }
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        SoundEffects.PlayOneShot(clip);
    }
}

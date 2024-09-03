using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySoundTrigger : MonoBehaviour
{

    [SerializeField] public enum TriggerState
    {
        
        OnTriggerEnter,
        OnTriggerExit,
    }

    public TriggerState triggerState;

    private void Awake()
    {
        triggerState = new TriggerState();
    }

    [SerializeField]string soundToPlay;
    bool hasPlayed;


    private void OnTriggerEnter(Collider other)
    {
        if (triggerState == TriggerState.OnTriggerEnter)
        {
            if (!hasPlayed && other.gameObject.tag == "Player" && SoundManager.Instance != null)
            {
                Debug.Log("Exit");     
                
                SoundManager.Instance.PlaySoundAtLocation(transform.position, soundToPlay, false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {     
        if(triggerState == TriggerState.OnTriggerExit)
        {
            if (!hasPlayed && other.gameObject.tag == "Player" && SoundManager.Instance != null)
            {
                Debug.Log("Enter");
                SoundManager.Instance.PlaySoundAtLocation(transform.position, soundToPlay, false);
            }
        }

    }

    
}

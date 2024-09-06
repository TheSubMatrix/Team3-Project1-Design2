using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class PlaySoundTrigger : MonoBehaviour
{
    [System.Serializable]
    public class UpdateUIUnityEvent : UnityEvent<Image, bool, float, float> { } 

    public UpdateUIUnityEvent updateUI;

    public Image updateImage;
   
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
                if(soundToPlay == "Dialogue 5")
                {

                    Debug.Log("Next Scene");
                    if(SceneTransition.Instance == null)
                    {
                        Debug.LogWarning("No instance");
                        return;
                    }
                    SceneTransition.Instance.ChangeScene(5, 1, "DemoScene");
                    
                    
                }
                Debug.Log("Exit");     
                
                SoundManager.Instance.PlaySoundAtLocation(transform.position, soundToPlay, false);
                Debug.Log("Show Image");
                updateUI?.Invoke(updateImage, true, 1, 2);
                hasPlayed = true;
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
                hasPlayed = true;
            }
        }

    }

    
}

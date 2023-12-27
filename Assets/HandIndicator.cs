using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIndicator : MonoBehaviour {

    public GameObject leftHand;
    public GameObject rightHand;

    public AudioClip clip;

    private void OnDestroy()
    {
        if(SoundController.Instance.playBackAudio)
        {
            SoundController.Instance.PlayClip(clip);
        }
    }
}

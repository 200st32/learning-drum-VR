using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour {

    public float speed;
    
    public void AssignSpeed()
    {
        SpeedController.Instance.speed = speed;
        DrumKitController.Instance.RestartBeat();
    }
}

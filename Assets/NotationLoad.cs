using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotationLoad : MonoBehaviour {

    public string hihat;
    public string snare;
    public string bass;
    public string hiTom;
    public string midTom;
    public string floorTom;
    public string cymbal;

    public void ChangeBeat()
    {
        DrumKitController.Instance.hihat.notation = hihat;
        DrumKitController.Instance.snare.notation = snare;
        DrumKitController.Instance.bass.notation = bass;
        DrumKitController.Instance.hiTom.notation = hiTom;
        DrumKitController.Instance.midTom.notation = midTom;
        DrumKitController.Instance.floorTom.notation = floorTom;
        DrumKitController.Instance.cymbal.notation = cymbal;

        DrumKitController.Instance.RestartBeat();

    }
}

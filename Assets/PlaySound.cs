using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class PlaySound : MonoBehaviour {

    private AudioSource source;
    //public bool playOnButtonPress = false;
    public bool button;
    public Collider infoholder;
    float rate = 0.1f;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
        InvokeRepeating("SlowUpdate", 0.0f, rate);
    }

    private void SlowUpdate()
    {/*
        if(OVRInput.Get(OVRInput.Button.One))
        {
            ActivateSound();
        }*/
        List<InputDevice> m_device = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, m_device);
        if (m_device.Count == 1)
        {
            CheckController(m_device[0]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        infoholder = other;
        if (other.tag == "DrumStickHead")
        {
            source.volume = other.gameObject.GetComponent<TrackSpeed>().speed;
            ActivateSound();
        }
    }

    private void CheckController(InputDevice d)
    {
        bool secondaryButtonDown = false;
        d.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButtonDown);
        if (secondaryButtonDown)
        {
            if(button == true)
            {
                ActivateSound();
            }
            
        }
    }

    private void ActivateSound()
    {
        source.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        source.Play();
    }
    /*
    void CheckButtonPress()
    {
        switch (button)
        {
            case "A":
                if (OVRInput.GetDown(OVRInput.RawButton.A)) ActivateSound();
                break;
            case "B":
                if (OVRInput.GetDown(OVRInput.RawButton.B)) ActivateSound();
                break;
        }
    }*/

}

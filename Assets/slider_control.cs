using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class slider_control : MonoBehaviour
{
    [SerializeField] private Slider myslider;
    [SerializeField] private TextMeshProUGUI mytext;
    private AudioSource source;
    float rate = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        InvokeRepeating("myUpdate", 0.0f, rate);
        myslider.onValueChanged.AddListener((v) =>
        {
            CancelInvoke("myUpdate");
            mytext.text = v.ToString("0");
            if (v != 0)
            {
                rate = 60 / v;
                InvokeRepeating("myUpdate", 0.0f, rate);
            }
        });
    }

    void myUpdate()
    {
        source.Play();
    }
}

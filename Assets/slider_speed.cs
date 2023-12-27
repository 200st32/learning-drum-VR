using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class slider_speed : MonoBehaviour
{
    [SerializeField] private Slider myslider;
    [SerializeField] private TextMeshProUGUI mytext;
    public GameObject panel;
    public float rate = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        myslider.onValueChanged.AddListener((v) =>
        {
            CancelInvoke("myUpdate");
            mytext.text = v.ToString("0");
            if (v != 0)
            {
                rate = 60 / v;
                myUpdate();
            }
        });
        void myUpdate()
        {
            panel.GetComponent<panel_controler>().Set_rate(rate);
        }
    }

}

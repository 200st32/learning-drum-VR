using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class lesson_control : MonoBehaviour
{
    private int state = 0;
    public GameObject canvas;
    private GameObject score;
    private int flag=0;
    public bool button;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void ChangeLesson(int a)
    {
        state = a;
    }
    // Update is called once per frame
    void Update()
    {
        List<InputDevice> m_device = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, m_device);
        if (m_device.Count == 1)
        {
            CheckController(m_device[0]);
        }
    }

    private void CheckController(InputDevice d)
    {
        bool secondaryButtonDown = false;
        d.TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButtonDown);
        if (secondaryButtonDown)
        {
            if (button == true)
            {
                if (state == 1)
                {
                    change();
                }
                else if (state >= 2)
                {
                    count_score();
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DrumStickHead")
        {
            if (state == 1)
            {
                change();
            }
            else if (state >= 2)
            {
                count_score();
            }    
                
        }

    }

    private void change()
    {
        if (flag == 0)
        {
            canvas.SetActive(true);
            flag = 1;
        }
        else
        {
            canvas.SetActive(false);
            flag = 0;
        }
        
    }

    private void count_score()
    {
        if (state == 2)
        {
            score = GameObject.Find("start lesson 2");
        }
        else if(state == 3)
        {
            score = GameObject.Find("start lesson 3");
        }

        if (this.gameObject.name == "snare drum colider")
        {
            score.GetComponent<Score>().change_hit(1);
        }
        else if (this.gameObject.name == "high hat colider")
        {
            score.GetComponent<Score>().change_hit(2);
        }
        else if (this.gameObject.name == "bass drum colider")
        {
            score.GetComponent<Score>().change_hit(3);
        }
        else if (this.gameObject.name == "cymbal colider")
        {
            score.GetComponent<Score>().change_hit(4);
        }
        else if (this.gameObject.name == "floor tom colider")
        {
            score.GetComponent<Score>().change_hit(5);
        }
        else if (this.gameObject.name == "rack tom large colider")
        {
            score.GetComponent<Score>().change_hit(6);
        }
        else if (this.gameObject.name == "rack tom small colider")
        {
            score.GetComponent<Score>().change_hit(7);
        }
    }

}

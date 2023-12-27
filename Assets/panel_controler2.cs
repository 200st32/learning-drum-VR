using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel_controler2 : MonoBehaviour
{
    private AudioSource[] source;
    public GameObject panel;
    public GameObject panel_hit;
    public GameObject task;
    public GameObject next;
    private GameObject child;
    private float rate = 1.2f;
    private int childnum = 0;
    public int[] pattern = { 9,2,8,2,9,2,8,2, 9, 2, 8, 2, 9, 2, 8, 2 };
    //snare:1 hihat:2 bass:3 cymbal:4 floortom: 5 largetom: 6 smalltom:7 1+2:8 3+2:9 
    public int now_play = 0;
    private int get_np_control = 0;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        source = GetComponents<AudioSource>();
        child = panel.transform.GetChild(0).gameObject;
        myReset();
        next.SetActive(false);

        yield return new WaitForSeconds(1);
        for (childnum = 0; childnum <= 15; childnum++)
        {
            yield return StartCoroutine(example(rate));
            child.SetActive(false);
        }
        childnum = 0;
        now_play = 0;
        Get_nowplay(1);
        //yield return new WaitForSeconds(1);
        for (childnum = 0; childnum <= 15; childnum++)
        {
            yield return StartCoroutine(myUpdate(rate));
            child.SetActive(false);
            GameObject c3 = panel_hit.transform.GetChild(childnum).gameObject;
            c3.SetActive(false);
        }
        now_play = -1;
        panel.SetActive(false);
        task.SetActive(false);
        next.SetActive(true);
    }
    private void myReset()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject c = panel.transform.GetChild(i).gameObject;
            c.SetActive(false);
            GameObject c1 = panel_hit.transform.GetChild(i).gameObject;
            c1.SetActive(false);
        }
    }
    IEnumerator example(float waitTime)
    {
        child = panel.transform.GetChild(childnum).gameObject;
        child.SetActive(true);
        if (pattern[now_play] == 8)
        {
            source[1].Play();
            source[2].Play();
            now_play++;
        }
        else if (pattern[now_play] == 2)
        {
            source[2].Play();
            now_play++;
        }
        else if (pattern[now_play] == 9)
        {
            source[3].Play();
            source[2].Play();
            now_play++;
        }
        yield return new WaitForSeconds(waitTime);
    }

    // Update is called once per frame
    IEnumerator myUpdate(float waitTime)
    {
        child = panel.transform.GetChild(childnum).gameObject;
        child.SetActive(true);
        source[0].Play();

        now_play++;
        yield return new WaitForSeconds(waitTime);
    }
    public void CorrectHit(int n)
    {
        GameObject c2 = panel_hit.transform.GetChild(n).gameObject;
        c2.SetActive(true);
    }
    public int Get_nowplay(int n)
    {
        if (n == 0)
        {
            if (get_np_control == 0)
            {
                return -1;
            }
            else if (get_np_control == 1)
            {
                return now_play;
            }
        }
        else if (n == 1)
        {
            get_np_control = 1;
        }
        return -1;
    }
}

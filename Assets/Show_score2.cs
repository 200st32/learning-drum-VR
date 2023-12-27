using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_score2 : MonoBehaviour
{
    [SerializeField] private Text m_MyText;
    public GameObject l2;
    private int s;
    // Start is called before the first frame update
    void Start()
    {
        s = l2.GetComponent<Score2>().getscore();
        m_MyText.text = s.ToString() + "/8";
    }
}

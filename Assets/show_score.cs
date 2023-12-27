using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_score : MonoBehaviour
{
    [SerializeField] private Text m_MyText;
    public GameObject l2;
    private int s;
    private int l;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Show()
    {
        s = l2.GetComponent<Score>().getscore();
        l = l2.GetComponent<panel_controler>().plen;
        m_MyText.text = s.ToString() + "/" + l.ToString();

    }
}

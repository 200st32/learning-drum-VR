using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{

    [SerializeField] private Text test;
    private int hit = 0;
    private int pre_hit = -1;
    private int[] p;
    private int my_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        p = this.GetComponent<panel_controler2>().pattern;
    }

    // Update is called once per frame
    /*IEnumerator myUpdate()
    {
        int np = this.GetComponent<panel_controler>().now_play;
        yield return new WaitUntil(() => np == -1);
        
        test.text = "np=" + np.ToString() + "hit=" + hit.ToString() + "pre_hit=" + pre_hit.ToString();
    }*/

    public int getscore()
    {
        return my_score;
    }
    public void change_hit(int n)
    {
        hit = n;
        int np = this.GetComponent<panel_controler2>().Get_nowplay(0);
        if (np != -1 && Check_hit(hit, p[np]))
        {
            if (pre_hit != np)
            {
                my_score++;
                pre_hit = np;
                this.GetComponent<panel_controler2>().CorrectHit(np);
            }
        }
        test.text = "np=" + np.ToString() + "hit=" + hit.ToString() + "score:" + my_score.ToString();
    }
    private bool Check_hit(int hit, int pnp)
    {
        if (pnp <= 7)
        {
            if (hit == pnp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (pnp == 8)
        {
            if (hit == 1 || hit == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (pnp == 9)
        {
            if (hit == 3 || hit == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

}

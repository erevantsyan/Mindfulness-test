using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItems : MonoBehaviour
{

    public StartPlay x;

    public GameObject TrueAns;
    public GameObject FalseAns;
    public GameObject Ans;

    public int pr = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag) pr = 1;
        if (x.count == 2)
        {
            pr = 2;
            if (other.gameObject.tag == gameObject.tag)
            {
                pr = 3;
                TrueAns.SetActive(true);
                FalseAns.SetActive(false);
            }
        }
    }
    
    void Update()
    {
        if (x.count == 2)
        {
            Ans.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItems : MonoBehaviour
{
    public GameObject TrueAns;
    public GameObject FalseAns;
    public GameObject Ans;

    public int pr = 0;

    private void OnTriggerStay(Collider other)
    {
        pr = 1;
        if (StaticCount.c1 == 2)
        {
            if (other.gameObject.tag == gameObject.tag)
            {
                TrueAns.SetActive(true);
                FalseAns.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pr = 0;
    }
    
    void Update()
    {
        if (StaticCount.c1 == 2)
        {
            Ans.SetActive(true);
        }
    }
}

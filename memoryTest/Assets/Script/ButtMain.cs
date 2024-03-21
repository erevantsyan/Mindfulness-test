using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;


public class ButtMain : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    public void Butt32()
    {
        SceneManager.LoadScene(1);
    }

    public void Butt33()
    {
        SceneManager.LoadScene(2);
    }

    public void Butt34()
    {
        SceneManager.LoadScene(3);
    }

    public void Butt35()
    {
        SceneManager.LoadScene(4);
    }

    public void Butt36()
    {
        SceneManager.LoadScene(5);
    }

    void Start(){
        ShowAdv();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public static class Extensions
{
    public static T[] RemoveAt<T>(this T[] source, int index)
    {
        return source.Where((_, i) => i != index).ToArray();
    }
}


public class StartPlay : MonoBehaviour
{

    [SerializeField] private int sec = 30;
    [SerializeField] private int sec1 = 120;
    [SerializeField] private int delta = 1;

    public int count = 0;

    public List<GameObject> Items = new List<GameObject> () {};

    public List<GameObject> Spawns = new List<GameObject> () {};

    public TMP_Text textTimer;

    private Coroutine  currentCoroutine;
    public List<GameObject> SpawnsBot = new List<GameObject> () {};
    public List<GameObject> SpawnsTop = new List<GameObject> () {};
    public List<GameObject> ItemsBot = new List<GameObject> () {};
    public List<GameObject> ItemsTop = new List<GameObject> () {};
    int[] array1 = {0, 1, 2, 3, 4, 5};
    int[] array2 = {0, 1, 2, 3, 4, 5};

    public GameObject Butt;
    public void StopTime(){
        sec1 = 4;
    }

    // Start is called before the first frame update
    void Start()
    {
        int[] array = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
        for (int i = 0; i < 12; i++)
        {
            int randomNum = UnityEngine.Random.Range(0, array.Length);
            Items[array[randomNum]].tag = (i + 1).ToString();
            Items[array[randomNum]].transform.position = new Vector3(Spawns[i].transform.position.x, Spawns[i].transform.position.y,Spawns[i].transform.position.z);
            array = array.RemoveAt(randomNum);
        }
        currentCoroutine = StartCoroutine(ITimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 1)
        {
            count = 0;
            stopCurrentCoroutine();
            Butt.SetActive (true);
            for (int i = 0; i < 6; i++)
            {
                int randomNum1 = UnityEngine.Random.Range(0, array1.Length);
                int randomNum2 = UnityEngine.Random.Range(0, array2.Length);
                ItemsBot[array1[randomNum1]].transform.position= new Vector3(SpawnsBot[i].transform.position.x, SpawnsBot[i].transform.position.y,SpawnsBot[i].transform.position.z);
                ItemsTop[array2[randomNum2]].transform.position= new Vector3(SpawnsTop[i].transform.position.x, SpawnsTop[i].transform.position.y,SpawnsTop[i].transform.position.z);
                array1 = array1.RemoveAt(randomNum1);
                array2 = array2.RemoveAt(randomNum2);
            }
            currentCoroutine = StartCoroutine(ITimerMain());
        }
        if (count == 2)
        {
            textTimer.enabled = false;
        }
    }

    IEnumerator ITimer()
    {
        while (true)
        {
            sec -= delta;
            textTimer.text = sec + "";
            if (sec <= 0)
            {
                count = 1;
            }
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator ITimerMain()
    {
        while (true)
        {
            sec1 -= delta;
            textTimer.text = sec1 / 60 + ":" + sec1 % 60;
            if (sec1 <= 0)
            {
                count = 2;
            }
            yield return new WaitForSeconds(1);
        }
    }

    void stopCurrentCoroutine() {
    if( currentCoroutine != null ) {
        StopCoroutine( currentCoroutine );
        currentCoroutine = null;
    }
}
}

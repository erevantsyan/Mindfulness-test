using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class StartPlay3x2 : MonoBehaviour
{
    [SerializeField] private int sec = 30;
    [SerializeField] private int sec1 = 120;
    [SerializeField] private int delta = 1;

    public List<GameObject> Items = new List<GameObject> () {};

    public List<GameObject> Spawns = new List<GameObject> () {};

    public TMP_Text textTimer;

    private Coroutine  currentCoroutine;
    public List<GameObject> SpawnsBot = new List<GameObject> () {};
    public List<GameObject> SpawnsTop = new List<GameObject> () {};
    public List<GameObject> ItemsBot = new List<GameObject> () {};
    public List<GameObject> ItemsTop = new List<GameObject> () {};
    int[] array1 = {0, 1, 2};
    int[] array2 = {0, 1, 2};

    public List<DragAndDrop> DragItem = new List<DragAndDrop> () {};


    public GameObject Butt;
    public GameObject ButtExit;

    public void StopTime(){
        sec1 = 4;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        int[] array = {0, 1, 2, 3, 4, 5};
        for (int i = 0; i < 6; i++)
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
        if (StaticCount.count == 1)
        {
            StaticCount.count = 0;
            StaticCount.c = 1;
            stopCurrentCoroutine();
            Butt.SetActive (true);
            for (int i = 0; i < 3; i++)
            {
                int randomNum1 = UnityEngine.Random.Range(0, array1.Length);
                ItemsBot[array1[randomNum1]].transform.position= new Vector3(SpawnsBot[i].transform.position.x, SpawnsBot[i].transform.position.y,SpawnsBot[i].transform.position.z);
                array1 = array1.RemoveAt(randomNum1);
            }
            for (int i = 0; i < 3; i++)
            {
                int randomNum2 = UnityEngine.Random.Range(0, array2.Length);
                ItemsTop[array2[randomNum2]].transform.position= new Vector3(SpawnsTop[i].transform.position.x, SpawnsTop[i].transform.position.y,SpawnsTop[i].transform.position.z);
                array2 = array2.RemoveAt(randomNum2);
            }
            for (int i = 0; i < 6; i++)
            {
                DragItem[i].enabled = true;
            }
            currentCoroutine = StartCoroutine(ITimerMain());
        }
        if (StaticCount.count == 2)
        {
            StaticCount.count = 0;
            StaticCount.c = 2;
            StaticCount.c1 = 2;
            textTimer.enabled = false;
            Butt.SetActive (false);
            ButtExit.SetActive (true);
            for (int i = 0; i < 6; i++)
            {
                DragItem[i].enabled = false;
            }
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
                StaticCount.count = 1;
            }
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator ITimerMain()
    {
        while (true)
        {
            sec1 -= delta;
            textTimer.text = sec1 + "";
            if (sec1 <= 0)
            {
                StaticCount.count = 2;
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

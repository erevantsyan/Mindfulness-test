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

    [SerializeField] private float sec = 30f;
    [SerializeField] private float delta = 1f;

    public int count = 0;

    public List<GameObject> Items = new List<GameObject> () {};

    public List<GameObject> Spawns = new List<GameObject> () {};

    public TMP_Text textTimer;


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
        StartCoroutine(ITimer());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ITimer()
    {
        while (true)
        {
            sec -= delta;
            textTimer.text = sec + "";
            if (sec <= 0f)
            {
                count = 1;
            }
            yield return new WaitForSeconds(1);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 pointScreen;
    private Vector3 offset;
    public float posX, posY, posZ;

    public int Num, count;

    public List<BoxCollider> BC = new List<BoxCollider> () {};

    public List<GameObject> Cell = new List<GameObject> () {};

    public List<CheckItems> checkItem = new List<CheckItems> () {};

    public StartPlay DragIt;

    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    void OnMouseDown()
    {
        if (DragIt.c == 1)
        {
            count = 0;
            pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z));
            for (int i = 0; i < 12; i++)
            {
                BC[i].enabled = true;
            }
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnMouseDrag()
    {
        if (DragIt.c == 1)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;
        }
    }

    void OnMouseUp()
    {
        if (DragIt.c == 1)
        {
            if (count == 0 || transform.position.y < 0.5 || checkItem[Num].pr == 1) transform.position = new Vector3(posX, posY, posZ);
            else transform.position = new Vector3(Cell[Num].transform.position.x, Cell[Num].transform.position.y, Cell[Num].transform.position.z);
            for (int i = 0; i < 12; i++)
            {
                BC[i].enabled = false;
            }
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "1")
        {
            count = 1;
            Num = 0;
        }
        if (other.gameObject.tag == "2")
        {
            count = 1;
            Num = 1;
        }
        if (other.gameObject.tag == "3")
        {
            count = 1;
            Num = 2;
        }
        if (other.gameObject.tag == "4")
        {
            count = 1;
            Num = 3;
        }
        if (other.gameObject.tag == "5")
        {
            count = 1;
            Num = 4;
        }
        if (other.gameObject.tag == "6")
        {
            count = 1;
            Num = 5;
        }
        if (other.gameObject.tag == "7")
        {
            count = 1;
            Num = 6;
        }
        if (other.gameObject.tag == "8")
        {
            count = 1;
            Num = 7;
        }
        if (other.gameObject.tag == "9")
        {
            count = 1;
            Num = 8;
        }
        if (other.gameObject.tag == "10")
        {
            count = 1;
            Num = 9;
        }
        if (other.gameObject.tag == "11")
        {
            count = 1;
            Num = 10;
        }
        if (other.gameObject.tag == "12")
        {
            count = 1;
            Num = 11;
        }
        if (other.gameObject.tag == "Spawn")
        {
            count = 0;
        }
    }
}

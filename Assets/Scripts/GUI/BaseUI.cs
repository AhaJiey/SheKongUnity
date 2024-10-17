using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    public GameObject UIobj;

    virtual public void show(){
        UIobj.SetActive(true);
    }

    virtual public void hide(){
        UIobj.SetActive(false);
    }
}

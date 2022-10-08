using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour
{
    [SerializeField] private bool isEmpty = true;
    [SerializeField] private bool mustBeFilled = false;

    public bool IsEmpty { 
        get { return isEmpty; }
        set { isEmpty = value; }
    }

    public bool MustBeFiled { get { return mustBeFilled; } }  

    private void Awake()
    {
        if(gameObject.transform.childCount != 0)
        {
            isEmpty = false;
        }
    }

}

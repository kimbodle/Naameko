using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool is1 = false;
    public bool is15 = false;
    
    public void Time1()
    {
        is1 = !is1;
    }

    public void Time15()
    {
        is15 = !is15;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamekoLibrary : MonoBehaviour
{
    public NamekoEntry[] namekoEntries;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var entry in namekoEntries)
        {
            if (GameManager.Instance.NamekoDictionary.TryGetValue(entry.id, out int count))
            {
                entry.UpdateEntry(count);
            }
            else
            {
                entry.UpdateEntry(0);
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

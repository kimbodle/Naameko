using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Dictionary<int, int> NamekoDictionary = new Dictionary<int, int>();
    public int totalNp = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HarvestNameko(int id, int np)
    {
        if (!NamekoDictionary.ContainsKey(id))
        {
            NamekoDictionary[id] = 0;
        }

        NamekoDictionary[id] += 1;
        totalNp += np;
        Debug.Log(id + ": 나메코 수확 총" + NamekoDictionary[id]);
    }

    public int GetTotalNp()
    {
        return totalNp;
    }
    
    public int GetNamekoCount(int id)
    {
        if (NamekoDictionary.ContainsKey(id))
        {
            return NamekoDictionary[id];
        }
        else
        {
            return 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Dictionary<int, int> NamekoDictionary = new Dictionary<int, int>();

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

    public void HarvestNameko(int id)
    {
        if (!NamekoDictionary.ContainsKey(id))
        {
            NamekoDictionary[id] = 0;
        }

        NamekoDictionary[id] += 1;
        Debug.Log(id + ",나메코 수확 1올라감. 총" + NamekoDictionary[id]);
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

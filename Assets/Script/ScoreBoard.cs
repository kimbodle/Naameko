using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [Header("NamekoHarvestedCount")]
    public TextMeshProUGUI Nameko0;  // id 0�� ������ ��Ȯ ������ ǥ���ϴ� TextMeshProUGUI
    public TextMeshProUGUI Nameko1;  // id 1 

    //������ ������ ���� id�� ��Ȯ������ dictionary�� ���� ����
    private Dictionary<int, int> harvestedCount = new Dictionary<int, int>();

    private void OnEnable()
    {
        Nameko.OnNamekoHarvested += UpdateScore;
    }

    private void OnDisable()
    {
        Nameko.OnNamekoHarvested -= UpdateScore;
    }

    private void UpdateScore(int id, Transform spawnLocation)
    {
        if(harvestedCount.ContainsKey(id))
        {
            harvestedCount[id] += 1;
        }
        else
        {
            harvestedCount[id] = 1;
        }

        //harvestedCount[id]�� ��Ȯ ���� ����
        switch (id)
        {
            case 0:
                Nameko0.text = "ID 0: " + harvestedCount[id];
                break;
            case 1:
                Nameko1.text = "ID 1: " + harvestedCount[id];
                break;
        }
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

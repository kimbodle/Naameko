using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [Header("NamekoHarvestedCount")]
    public TextMeshProUGUI Nameko0;  // id 0의 나메코 수확 개수를 표시하는 TextMeshProUGUI
    public TextMeshProUGUI Nameko1;  // id 1 
    public TextMeshProUGUI SumNpText; //총 NP

    private int npSum=0;

    //나메코 종류에 따른 id와 수확갯수를 dictionary를 통해 저장 -> 수확 갯수는 Gamemanager에서,Score에서는 Np를 저장
    private Dictionary<int, int> harvestedCount = new Dictionary<int, int>();

    private void OnEnable()
    {
        Nameko.OnNamekoHarvested += UpdateScore;
    }

    private void OnDisable()
    {
        Nameko.OnNamekoHarvested -= UpdateScore;
    }

    private void UpdateScore(int id,int Np, Transform spawnLocation)
    {
        if(harvestedCount.ContainsKey(id))
        {
            harvestedCount[id] += Np;
            npSum += Np;
        }
        else
        {
            harvestedCount[id] = Np;
            npSum += Np;
        }

        SumNpText.text = npSum.ToString();

        //harvestedCount[id]에 수확 갯수 저장
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
        SumNpText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

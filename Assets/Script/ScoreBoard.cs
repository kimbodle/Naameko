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

    private GameManager gameManager; // GameManager 클래스 참조

    //나메코 종류에 따른 id와 수확갯수를 dictionary를 통해 저장 -> 수확 갯수는 Gamemanager에서,Score에서는 Np를 저장
    private Dictionary<int, int> harvestedCount = new Dictionary<int, int>();

    private void OnEnable()
    {
        HavestEventManager.OnNamekoHarvested += UpdateScore;
    }

    private void OnDisable()
    {
        HavestEventManager.OnNamekoHarvested -= UpdateScore;
    }

    private void UpdateScore(int id,int Np, Transform spawnLocation)
    {
        // GameManager에서 NP와 나메코 수확 개수를 가져와 표시
        SumNpText.text = gameManager.GetTotalNp().ToString();

        if (harvestedCount.ContainsKey(id))
        {
            harvestedCount[id] += Np;
        }
        else
        {
            harvestedCount[id] = Np; 
        } //이 if문은 없어도 되지만 일단 각 나메코별로 얼만큼 총 NP가 쌓였는지 궁금해서 넣는 코드

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
        // GameManager 인스턴스 참조
        gameManager = GameManager.Instance;

        SumNpText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

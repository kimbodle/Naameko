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
    public TextMeshProUGUI SumNpText; //�� NP

    private GameManager gameManager; // GameManager Ŭ���� ����

    //������ ������ ���� id�� ��Ȯ������ dictionary�� ���� ���� -> ��Ȯ ������ Gamemanager����,Score������ Np�� ����
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
        // GameManager���� NP�� ������ ��Ȯ ������ ������ ǥ��
        SumNpText.text = gameManager.GetTotalNp().ToString();

        if (harvestedCount.ContainsKey(id))
        {
            harvestedCount[id] += Np;
        }
        else
        {
            harvestedCount[id] = Np; 
        } //�� if���� ��� ������ �ϴ� �� �����ں��� ��ŭ �� NP�� �׿����� �ñ��ؼ� �ִ� �ڵ�

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
        // GameManager �ν��Ͻ� ����
        gameManager = GameManager.Instance;

        SumNpText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

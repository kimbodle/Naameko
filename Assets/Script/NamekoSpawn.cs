using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class NamekoSpawn : MonoBehaviour
{
    [Header("Nameko")]
    [SerializeField]
    private Transform[] spawnPrefab;
    [SerializeField]
    private GameObject[] Namekos;

    private List<Transform> activespawnPrefabList; //������ ���� ������ ��ġ�� ���� ����Ʈ
    private Dictionary<string, Transform> spawnedNamekos = new Dictionary<string, Transform>(); // ������ ������ ���� ��ġ ���� �� �ʱ�ȭ

    [Header("Item")]
    public ItemManager itemManager;
    private float spawnTime = 0f;

    [Header("NamekoSpawnProbability")]
    [SerializeField]
    private float[] spawnProbability;

    [SerializeField]
    public GameObject parentObject; //���̶�Ű

    // Start is called before the first frame update
    void Start()
    {
        activespawnPrefabList = new List<Transform>(spawnPrefab);  // ó���� ��� ��ġ���� ����
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemManager.is1)
        {
            spawnTime = 10f;
        }
        else if (itemManager.is15)
        {
            spawnTime = 60f;
        } //�ð� ������ ���� ���� �ӵ��� �ٸ�. �����ۿ� ���� �ð� ����
       
    }
    void OnEnable()
    {
        Nameko.OnNamekoHarvested += OnNamekoHarvestedPlace; //�̺�Ʈ ���� ȣ��
        StartCoroutine(SpawnNameko());
    }

    void OnDisable()
    {
        Nameko.OnNamekoHarvested -= OnNamekoHarvestedPlace;
        StopCoroutine(SpawnNameko());  // Coroutine ����
    }

    IEnumerator SpawnNameko()
    {
        while (true)
        {
            //Debug.Log("���� ����");
            float spawnInterval = Random.Range(3, spawnTime + 1); //10�ʺ��� spawntime ����
            Debug.Log(spawnInterval);
            yield return new WaitForSeconds(spawnInterval); //���� �ð� ��ٸ�
            //Debug.Log("���� ��ٸ�");

            if (activespawnPrefabList.Count > 0 && itemManager.SpawnOk == true)  //���� ������ ��ġ�� �������� ������ ����
            {
                //Debug.Log("������ġ ����");
                int spawnPointIndex = Random.Range(0, activespawnPrefabList.Count);  //��밡���� ������ġ �� ���� ����
                Transform spawnLocation = activespawnPrefabList[spawnPointIndex];  // ������ ���� ��ġ ������
                //activespawnPrefabList.RemoveAt(spawnPointIndex);  // ������ ��ġ�� ��� ������ ��ġ ����Ʈ���� ����

                spawnLocation.gameObject.SetActive(false);

                if (!spawnedNamekos.ContainsKey(spawnLocation.position.ToString()))
                {
                    //int NamekoIndex = Random.Range(0, Nameko.Length);  // ������ �����ڸ� ����
                    int NamekoIndex = SelectIndexProbability(spawnProbability);

                    GameObject nameko = Instantiate(Namekos[NamekoIndex], spawnLocation.transform.position, Quaternion.identity, parentObject.transform);  // ������ ����

                    spawnedNamekos.Add(spawnLocation.position.ToString(), spawnLocation);
                    // ������ ���� ��ġ�� ������ �����ڸ� Dictionary�� �߰�

                    //Debug.Log(spawnLocation.position.ToString());
                    Debug.Log("������ �������� ��ġ�� spawnedNamekos�� �߰�. ���� ������ ����: " + spawnedNamekos.Count);
                }
            }
        }

    }

    void OnNamekoHarvestedPlace(int id,int Np, Transform spawnLocation)
    {
        //Debug.Log(spawnLocation.position.ToString());
        if (spawnedNamekos.ContainsKey(spawnLocation.position.ToString()))
        {
            Debug.Log("��Ȯ�� �������� ��ġ�� ����� ������ġ�� �ٽ� Ȱ��ȭ.");
            spawnLocation.gameObject.SetActive(true);
            spawnedNamekos.Remove(spawnLocation.position.ToString());
        }
        else
        {
            Debug.Log("��Ȯ�� �������� ��ġ�� ã�� �� ����. in spawnedNamekos.");
        }
    }

    private int SelectIndexProbability(float[] probabilities)
    {
        float total = 0;
        foreach (float pro in probabilities)
        {
            total += pro; //��� Ȯ�� ���� ��ħ
        }

        float randomPorint = Random.value * total; //0�� 1������ �������� total�� ���Ͽ� 0���� total������ �������� ����

        for(int i=0; i < probabilities.Length; i++) //Ȯ�� �迭 ��ȸ
        {
            if(randomPorint < probabilities[i]) //�������� ���� Ȯ������ ������ ���� �ε��� ��ȯ.->�������� ���� Ȯ�������� ����
            {
                return i;
            }
            else
            {
                randomPorint -= probabilities[i]; //���������� ���� Ȯ������ �� -> �������� ���� Ȯ�� ������ �̵�
            }
        }
        return probabilities.Length-1;
    } //Ȯ�� ���� ū �ε����ϼ��� �� ���� ���õ�
}

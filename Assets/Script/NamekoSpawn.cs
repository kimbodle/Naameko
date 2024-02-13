using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NamekoSpawn : MonoBehaviour
{
    [Header("Nameko")]
    [SerializeField]
    private Transform[] spawnPrefab;
    [SerializeField]
    private GameObject[] Nameko;

    private List<Transform> activespawnPrefabList;

    [Header("Item")]
    public ItemManager itemManager;
    private float spawnTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        activespawnPrefabList = new List<Transform>(spawnPrefab);  // ó���� ��� ��ġ���� ����
        StartCoroutine(SpawnNameko());
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
        }
    }

    IEnumerator SpawnNameko()
    {
        while (true)
        {
            Debug.Log("���� ����");
            float spawnInterval = Random.Range(10, spawnTime + 1); //10�ʺ��� spawntime ����
            Debug.Log(spawnInterval);
            yield return new WaitForSeconds(spawnInterval); //���� �ð� ��ٸ�
            Debug.Log("���� ��ٸ�");

            if (activespawnPrefabList.Count > 0)  //���� ������ ��ġ�� �������� ������ ����
            {
                Debug.Log("������ġ ����");
                int spawnPointIndex = Random.Range(0, activespawnPrefabList.Count);  //��밡���� ������ġ �� ���� ����

                Transform spawnLocation = activespawnPrefabList[spawnPointIndex];  // ������ ���� ��ġ ������
                activespawnPrefabList.RemoveAt(spawnPointIndex);  // ������ ��ġ�� ��� ������ ��ġ ����Ʈ���� ����

                int NamekoIndex = Random.Range(0, Nameko.Length);  // ������ �����ڸ� ����
                GameObject nameko = Instantiate(Nameko[NamekoIndex], spawnLocation.transform.position, Quaternion.identity);  // �����ڸ� ����

                /*
                // ������ �����ڿ� Nameko ������Ʈ�� �ִٸ�, ��Ȯ�Ǿ��� �� �̺�Ʈ�� �߰��մϴ�.
                Nameko namekoComponent = nameko.GetComponent<Nameko>();
                if (namekoComponent != null)
                {
                    namekoComponent.OnHarvested += () => { availableSpawnLocations.Add(spawnLocation); };  // �����ڰ� ��Ȯ�Ǹ�, �ش� ��ġ�� �ٽ� ��� ������ ��ġ ����Ʈ�� �߰��մϴ�.
                }
                */
            }
        }

    }
}

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

    private List<Transform> activespawnPrefabList; //나메코 스폰 가능한 위치를 담은 리스트
    private Dictionary<string, Transform> spawnedNamekos = new Dictionary<string, Transform>(); // 스폰된 나메코 스폰 위치 선언 및 초기화

    [Header("Item")]
    public ItemManager itemManager;
    private float spawnTime = 0f;
    private float minSpawnTime = 0f;

    [Header("NamekoSpawnProbability")]
    [SerializeField]
    private float[] spawnProbability;

    [SerializeField]
    public GameObject parentObject; //하이라키

    float Time = 180f;

    // Start is called before the first frame update
    void Start()
    {
        activespawnPrefabList = new List<Transform>(spawnPrefab);  // 처음은 모든 위치에서 스폰

    }

    // Update is called once per frame
    void Update()
    {
        if (itemManager.is1)
        {
            minSpawnTime = 3f;
            spawnTime = 10f;
        }
        else if (itemManager.is15)
        {
            minSpawnTime = 5f;
            spawnTime = 60f;
        } //시간 아이템 마다 스폰 속도가 다름. 아이템에 따라 시간 조절

        if (itemManager.itemFull)
        {
            StartCoroutine(ItemFullCoroutine());
        }

    }
    void OnEnable()
    {
        HavestEventManager.OnNamekoHarvested += OnNamekoHarvestedPlace; //이벤트 구독 호출
        StartCoroutine(SpawnNameko());
    }

    void OnDisable()
    {
        HavestEventManager.OnNamekoHarvested -= OnNamekoHarvestedPlace;
        StopCoroutine(SpawnNameko());  // Coroutine 중지
    }

    IEnumerator SpawnNameko()
    {
        while (true)
        {
            //Debug.Log("스폰 시작");
            float spawnInterval = Random.Range(minSpawnTime, spawnTime); //10초부터 spawntime 사이
            Debug.Log(spawnInterval);
            yield return new WaitForSeconds(spawnInterval); //일정 시간 기다림
            //Debug.Log("스폰 기다림");

            if (activespawnPrefabList.Count > 0 && itemManager.SpawnOk == true)  //스폰 가능한 위치가 있을때만 나메코 생성
            {
                Debug.Log("스폰위치 있음");
                int spawnPointIndex = Random.Range(0, activespawnPrefabList.Count);  //사용가능한 스폰위치 중 랜덤 선택
                Transform spawnLocation = activespawnPrefabList[spawnPointIndex];  // 선택한 스폰 위치 가져옴
                //activespawnPrefabList.RemoveAt(spawnPointIndex);  // 선택한 위치를 사용 가능한 위치 리스트에서 제거

                spawnLocation.gameObject.SetActive(false);

                if (!spawnedNamekos.ContainsKey(spawnLocation.position.ToString()))
                {
                    //int NamekoIndex = Random.Range(0, Nameko.Length);  // 랜덤한 나메코를 선택
                    int NamekoIndex = SelectIndexProbability(spawnProbability);

                    GameObject nameko = Instantiate(Namekos[NamekoIndex], spawnLocation.transform.position, Quaternion.identity, parentObject.transform);  // 나메코 생성

                    spawnedNamekos.Add(spawnLocation.position.ToString(), spawnLocation);
                    // 나메코 생성 위치와 생성된 나메코를 Dictionary에 추가

                    //Debug.Log(spawnLocation.position.ToString());
                    Debug.Log("스폰된 나메코의 위치를 spawnedNamekos에 추가. 현재 나메코 갯수: " + spawnedNamekos.Count);
                }
            }
        }

    }

    void OnNamekoHarvestedPlace(int id, int Np, Transform spawnLocation)
    {
        //Debug.Log(spawnLocation.position.ToString());
        if (spawnedNamekos.ContainsKey(spawnLocation.position.ToString()))
        {
            Debug.Log("수확된 나메코의 위치를 지우고 스폰위치를 다시 활성화.");
            spawnLocation.gameObject.SetActive(true);
            spawnedNamekos.Remove(spawnLocation.position.ToString());
        }
        else
        {
            Debug.Log("수확된 나메코의 위치를 찾을 수 없음. in spawnedNamekos.");
        }
    }

    private int SelectIndexProbability(float[] probabilities)
    {
        float total = 0;
        foreach (float pro in probabilities)
        {
            total += pro; //모든 확률 값을 합침
        }

        float randomPorint = Random.value * total; //0과 1사이의 랜덤값을 total과 곱하여 0부터 total까지의 랜덤값을 얻음

        for (int i = 0; i < probabilities.Length; i++) //확률 배열 순회
        {
            if (randomPorint < probabilities[i]) //랜덤값이 현재 확률보다 작으면 현재 인덱스 반환.->랜덤값이 현재 확률범위에 속함
            {
                return i;
            }
            else
            {
                randomPorint -= probabilities[i]; //랜덤값에서 현재 확률값을 뺌 -> 랜덤값을 다음 확률 범위로 이동
            }
        }
        return probabilities.Length - 1;
    } //확률 값이 큰 인덱스일수록 더 자주 선택됨

    IEnumerator ItemFullCoroutine()
    {
        while (Time > 0)
        {
            minSpawnTime = 0f;
            spawnTime = 1f;
            Time -= 1f;
            yield return null;
        }
        itemManager.itemFull = false;
        Time = 180f;
    }
}
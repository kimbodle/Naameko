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

    [Header("NamekoSpawnProbability")]
    [SerializeField]
    private float[] spawnProbability;


    // Start is called before the first frame update
    void Start()
    {
        activespawnPrefabList = new List<Transform>(spawnPrefab);  // 처음은 모든 위치에서 스폰
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
            Debug.Log("스폰 시작");
            float spawnInterval = Random.Range(10, spawnTime + 1); //10초부터 spawntime 사이
            Debug.Log(spawnInterval);
            yield return new WaitForSeconds(spawnInterval); //일정 시간 기다림
            Debug.Log("스폰 기다림");

            if (activespawnPrefabList.Count > 0)  //스폰 가능한 위치가 있을때만 나메코 생성
            {
                Debug.Log("스폰위치 있음");
                int spawnPointIndex = Random.Range(0, activespawnPrefabList.Count);  //사용가능한 스폰위치 중 랜덤 선택

                Transform spawnLocation = activespawnPrefabList[spawnPointIndex];  // 선택한 스폰 위치 가져옴
                activespawnPrefabList.RemoveAt(spawnPointIndex);  // 선택한 위치를 사용 가능한 위치 리스트에서 제거

                //int NamekoIndex = Random.Range(0, Nameko.Length);  // 랜덤한 나메코를 선택
                int NamekoIndex = SelectIndexProbability(spawnProbability);
                GameObject nameko = Instantiate(Nameko[NamekoIndex], spawnLocation.transform.position, Quaternion.identity);  // 나메코를 생성

                /*
                // 생성된 나메코에 Nameko 컴포넌트가 있다면, 수확되었을 때 이벤트를 추가합니다.
                Nameko namekoComponent = nameko.GetComponent<Nameko>();
                if (namekoComponent != null)
                {
                    namekoComponent.OnHarvested += () => { availableSpawnLocations.Add(spawnLocation); };  // 나메코가 수확되면, 해당 위치를 다시 사용 가능한 위치 리스트에 추가합니다.
                }
                */
            }
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

        for(int i=0; i < probabilities.Length; i++) //확률 배열 순회
        {
            if(randomPorint < probabilities[i]) //랜덤값이 현재 확률보다 작으면 현재 인덱스 반환.->랜덤값이 현재 확률범위에 속함
            {
                return i;
            }
            else
            {
                randomPorint -= probabilities[i]; //랜덤값에서 현재 확률값을 뺌 -> 랜덤값을 다음 확률 범위로 이동
            }
        }
        return probabilities.Length-1;
    } //확률 값이 큰 인덱스일수록 더 자주 선택됨
}

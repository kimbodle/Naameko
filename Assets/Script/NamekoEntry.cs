using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class NamekoEntry : MonoBehaviour
{
    public int id;

    [Header("NamekoInfo")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI descriptionText;
    public Image namekoImage;
    
    [Header("Details")]
    public GameObject detailPanel;  // 나메코의 상세 정보를 표시하는 패널
    public Image[] Trophys;
    public TextMeshProUGUI DetailCountText;

    [SerializeField]
    private int trophysCount = 0;

    public void UpdateEntry(int count)
    {
        countText.text = "수확 횟수: " + count;
        if (count > 0)
        {
            namekoImage.enabled = true;
            nameText.enabled = true;
            descriptionText.enabled = true;
            DetailCountText.text = count.ToString();

            if (5 > count && count > 2)
            {
                trophysCount = 1;
                //Debug.Log("엔트리의 카운트와 트로피카운트" + count + "공백" + trophysCount);
            }
            else if(count >= 5)
            {
                trophysCount = 2;
            }
        }
        else
        {
            namekoImage.enabled = false;
            nameText.enabled = false;
            descriptionText.enabled = false;
        }
    }
    public void OnDetails()
    {
        Debug.Log("비활성화");

        if (namekoImage.enabled)  // 수확 횟수가 1 이상인 경우
        {
            //나메코 항목을 터치했을 때 상세 정보를 표시하는 코드
            detailPanel.SetActive(true);  // 상세 정보 패널을 활성화
            EventSystem.current.SetSelectedGameObject(detailPanel);
            Trophys[1].enabled = false;
            Trophys[0].enabled = false;
 
            if (trophysCount == 1)
            {
                Trophys[1].enabled = false;
                Trophys[0].enabled = true;
            }
            else if(trophysCount == 2)
            {
                Trophys[1].enabled = true;
            }
        }

    }

    public void ClosePanel()
    {
        detailPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class NamekoEntry : MonoBehaviour
{
    public int id;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI DetailCountText;
    public Image namekoImage;

    public GameObject detailPanel;  // 나메코의 상세 정보를 표시하는 패널

    public void UpdateEntry(int count)
    {
        countText.text = "수확 횟수: " + count;
        if (count > 0)
        {
            namekoImage.enabled = true;
            nameText.enabled = true;
            descriptionText.enabled = true;
            DetailCountText.text = count.ToString();
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
            // 여기에 나메코 항목을 터치했을 때 상세 정보를 표시하는 코드를 추가하세요.
            detailPanel.SetActive(true);  // 상세 정보 패널을 활성화
            // 여기에 패널에 나메코의 상세 정보를 표시하는 코드를 추가하세요.
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

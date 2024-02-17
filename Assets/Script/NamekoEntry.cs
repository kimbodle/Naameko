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
    public GameObject detailPanel;  // �������� �� ������ ǥ���ϴ� �г�
    public Image[] Trophys;
    public TextMeshProUGUI DetailCountText;

    [SerializeField]
    private int trophysCount = 0;

    public void UpdateEntry(int count)
    {
        countText.text = "��Ȯ Ƚ��: " + count;
        if (count > 0)
        {
            namekoImage.enabled = true;
            nameText.enabled = true;
            descriptionText.enabled = true;
            DetailCountText.text = count.ToString();

            if (5 > count && count > 2)
            {
                trophysCount = 1;
                //Debug.Log("��Ʈ���� ī��Ʈ�� Ʈ����ī��Ʈ" + count + "����" + trophysCount);
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
        Debug.Log("��Ȱ��ȭ");

        if (namekoImage.enabled)  // ��Ȯ Ƚ���� 1 �̻��� ���
        {
            //������ �׸��� ��ġ���� �� �� ������ ǥ���ϴ� �ڵ�
            detailPanel.SetActive(true);  // �� ���� �г��� Ȱ��ȭ
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

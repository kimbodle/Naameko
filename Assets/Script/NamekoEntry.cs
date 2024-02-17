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

    public GameObject detailPanel;  // �������� �� ������ ǥ���ϴ� �г�

    public void UpdateEntry(int count)
    {
        countText.text = "��Ȯ Ƚ��: " + count;
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
        Debug.Log("��Ȱ��ȭ");

        if (namekoImage.enabled)  // ��Ȯ Ƚ���� 1 �̻��� ���
        {
            // ���⿡ ������ �׸��� ��ġ���� �� �� ������ ǥ���ϴ� �ڵ带 �߰��ϼ���.
            detailPanel.SetActive(true);  // �� ���� �г��� Ȱ��ȭ
            // ���⿡ �гο� �������� �� ������ ǥ���ϴ� �ڵ带 �߰��ϼ���.
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

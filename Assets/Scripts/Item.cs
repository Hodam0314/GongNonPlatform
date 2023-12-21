using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    InventoryManager InvenManager;
    SpriteRenderer sr;
    Sprite sprite;


    private void Awake()
    {
        //�κ� �Ŵ��� ������ٰ�
        InvenManager = InventoryManager.Instance;
        sr = GetComponent<SpriteRenderer>();
        sprite = sr.sprite;
    }

    public void GetItem()
    {
        if (InvenManager.GetItem(sprite))
        {
            Destroy(gameObject); //�κ��Ŵ����� ���� �� �������� ����Ҽ� �ִٸ� ����� ����
        }
        else
        {
            Debug.Log("������ â�� ���� á���ϴ�");
        }
    }


}

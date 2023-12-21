using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("�մ�������!")]
    [SerializeField, Tooltip("������Ʈ�� ���� �״� �Ҷ� ����ϴ� ������Ʈ")] GameObject objInventory; //������Ʈ ��ü
    [SerializeField, Tooltip("������ ������Ʈ")] GameObject objItem;//�κ��丮�� ������ ������ ������Ʈ�� ��������
    [SerializeField] Transform trsInven;//�κ��丮 �ʱ�ȭ�� ����� �κ��丮���� ��ġ������

    private List<Transform> listInven = new List<Transform>();//�κ��丮 ����

    [SerializeField] KeyCode openInvenKey;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    void Start()
    {
        initInven();
    }

    private void initInven()
    {
        listInven.Clear();
        listInven.AddRange(trsInven.GetComponentsInChildren<Transform>());
        listInven.RemoveAt(0);//�ڵ带 ������ �� ������Ʈ�� Trasnfrom�� �������⶧���� 0���� ����(0���� �� ������Ʈ�� Transform)
    }

    void Update()
    {
        openInventory();
    }

    private void openInventory()
    {
        if (Input.GetKeyDown(openInvenKey))
        {
            if(objInventory.activeSelf == true)
            {
                objInventory.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                objInventory.SetActive(true);
                Time.timeScale = 0.0f;
            }
            //objInventory.SetActive(!objInventory.activeSelf);
        }
    }

    private int getEmptyITemSlot()
    {
        int count = listInven.Count;
        for(int i = 0; i < count; ++i)
        {
            Transform slot = listInven[i];
            if(slot.childCount == 0)//��ġ�� �ڽ��� ���ٸ� �������
            {
                return i;
            }
        }
        return -1;
    }

    public bool GetItem(Sprite _spr)
    {
        int slotNum = getEmptyITemSlot();
        if (slotNum == -1)
        {
            return false;
        }

        InvenDragUI ui = Instantiate(objItem, listInven[slotNum])?.GetComponent<InvenDragUI>(); ;
        //ui��ũ��Ʈ���� �̾����� ������ ��� ��ų ����
        ui.SetItem(_spr);

        return true;
    }
}

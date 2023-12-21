using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("손대지말것!")]
    [SerializeField, Tooltip("오브젝트를 껏다 켰다 할때 사용하는 오브젝트")] GameObject objInventory; //오브젝트 본체
    [SerializeField, Tooltip("프리팹 오브젝트")] GameObject objItem;//인벤토리에 생성된 프리팹 오브젝트의 오리지널
    [SerializeField] Transform trsInven;//인벤토리 초기화에 사용할 인벤토리들의 위치데이터

    private List<Transform> listInven = new List<Transform>();//인벤토리 슬롯

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
        listInven.RemoveAt(0);//코드를 실행한 이 오브젝트의 Trasnfrom도 가져오기때문에 0번을 삭제(0번은 이 오브젝트의 Transform)
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
            if(slot.childCount == 0)//위치에 자식이 없다면 비어있음
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
        //ui스크립트에서 이아이템 정보를 등록 시킬 예정
        ui.SetItem(_spr);

        return true;
    }
}

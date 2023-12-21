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
        //인벤 매니저 등록해줄것
        InvenManager = InventoryManager.Instance;
        sr = GetComponent<SpriteRenderer>();
        sprite = sr.sprite;
    }

    public void GetItem()
    {
        if (InvenManager.GetItem(sprite))
        {
            Destroy(gameObject); //인벤매니저로 부터 이 아이템을 등록할수 있다면 등록후 삭제
        }
        else
        {
            Debug.Log("아이템 창이 가득 찼습니다");
        }
    }


}

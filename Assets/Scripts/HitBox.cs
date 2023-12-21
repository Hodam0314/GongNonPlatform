using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private Player.hitType hitType;
    //[SerializeField] private LayerMask layer;
    Player player;



    void Start()
    {
        player = GetComponentInParent<Player>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //int value = (int)Mathf.Log(layer, 2); //64 그라운드
        //if(collision.gameObject.layer == value) // 6 == 64 틀렸다.
        //{
        player.TrigerEnter(hitType, collision);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == layer)
        //{
        player.TrigerExit(hitType, collision);
        //}
    }
}

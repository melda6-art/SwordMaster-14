using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameObjectTest : MonoBehaviour
{
    public GameObject ObjectA;
    public SpriteRenderer ObjectB;
    public GameObject ObjectC;

    public float JumpHeight = 5f;
    public string ObjectName = "Triangle";
    public float MovementSpeed = 6f;
    public float ObjectHealth = 100f;
    public bool isAlive = true;

    private void Start()
    {
        print(ObjectA.name);
        print(ObjectB.name);
        print(ObjectC.name);
        print(gameObject.name);
        ObjectA.GetComponent<SpriteRenderer>().color = Color.blue;
        ObjectB.color = Color.black;
        
    }
}

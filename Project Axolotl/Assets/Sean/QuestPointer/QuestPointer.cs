using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPointer : MonoBehaviour
{
    public GameObject questobject;
    public GameObject player;
    private Vector3 targetPos;
    [SerializeField] private float rotateDampen = 2f;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = questobject.transform.position;
        Vector3 lookpos = targetPos - player.transform.position;
    
        
        float angle = Mathf.Atan2(lookpos.y, lookpos.x) * Mathf.Rad2Deg;
        Quaternion rotate  = Quaternion.Euler(new Vector3(0, 0, angle));
        
        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, rotateDampen * Time.deltaTime);    
    }
}

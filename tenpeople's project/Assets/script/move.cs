﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    // Use this for initialization
    public float preparetime;
    float tempTime = 0f;
    int A=1;
    void Start () {
        float time = Time.time;
        tempTime = time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float time = Time.time;
        if ((time - tempTime > preparetime) && (A==1))
        {
            gameObject.transform.Translate(Vector2.up * 3 * Time.deltaTime);
        }
        if (A == 0)
        {
            gameObject.transform.Translate(Vector2.left * 3 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "left")
        {
            A = 0;
        } 

    }
}

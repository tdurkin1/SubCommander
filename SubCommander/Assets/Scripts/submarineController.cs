using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submarineController : MonoBehaviour
{
    [SerializeField] float subSpeed = 0.2f;
    [SerializeField] float moveStep = 1f;
    [SerializeField] float rotateStep = 1f;
    [SerializeField] GameObject sub;
    
    private bool periscope;
    public bool Periscope
    {
        get { return periscope; }
        set { periscope = value; }
    }
    
    void Start()
    {
        periscope = false;
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if(!periscope)
        {
            //move sub            
            if (Input.GetKey("q"))
            {
                Debug.Log("up");
                Vector3 targetPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, subSpeed * Time.deltaTime);
            }
            else if (Input.GetKey("e"))
            {
                Debug.Log("down");
                Vector3 targetPos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, subSpeed * Time.deltaTime);
            }
            else if (Input.GetKey("w"))
            {
                Debug.Log("forward");
                Vector3 targetPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, subSpeed * Time.deltaTime);
            }
            else if (Input.GetKey("s"))
            {
                Debug.Log("back");
                Vector3 targetPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, subSpeed * Time.deltaTime);
            }
        }
        else
        {
            //control periscope
        }
    }
}

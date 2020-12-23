using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submarineController : MonoBehaviour
{
    [SerializeField] float subSpeed = 0.2f;
    [SerializeField] float moveStep = 1f;
    [SerializeField] float rotateStep = 1f;
    [SerializeField] Light subLight;
    [SerializeField] ParticleSystem propBubbles;
    
    private bool periscope;
    public bool Periscope
    {
        get { return periscope; }
        set { periscope = value; }
    }

    private bool lightOn;

    void Start()
    {
        periscope = false;
        lightOn = false;
    }

    void Update()
    {
        HandleMovement();
        HandleLight();
    }

    private void HandleMovement()
    {
        if(!periscope)
        {
            //move sub            
            if (Input.GetKey("q"))
            {
                Debug.Log("up");
                Vector3 targetPos = new Vector3(transform.position.x, transform.position.y + moveStep, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, subSpeed * Time.deltaTime);
                propBubbles.Play();
            }
            else if (Input.GetKey("e"))
            {
                Debug.Log("down");
                Vector3 targetPos = new Vector3(transform.position.x, transform.position.y - moveStep, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, subSpeed * Time.deltaTime);
                propBubbles.Play();
            }
            else if (Input.GetKey("w"))
            {
                Debug.Log("forward");
                Vector3 targetPos = new Vector3(transform.position.x - moveStep, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, subSpeed * Time.deltaTime);
                propBubbles.Play();
            }
            else if (Input.GetKey("s"))
            {
                Debug.Log("back");
                Vector3 targetPos = new Vector3(transform.position.x + moveStep, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPos, subSpeed * Time.deltaTime);
                propBubbles.Play();
            }
            else
            {               
                StartCoroutine(stopBubbles());
            }
        }
        else
        {
            //control periscope
        }        
    }
    void HandleLight()
    {
        if (Input.GetKeyDown("l"))
        {
            if (lightOn)
            {
                subLight.gameObject.SetActive(false);
                lightOn = false;
            }
            else
            {
                subLight.gameObject.SetActive(true);
                lightOn = true;
            }
        }
    }

    IEnumerator stopBubbles()
    {
        yield return new WaitForSeconds(0.1f);
        propBubbles.Stop();
    }
}

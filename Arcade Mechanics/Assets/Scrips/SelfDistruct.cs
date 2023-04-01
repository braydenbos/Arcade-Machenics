using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDistruct : MonoBehaviour
{
    private float timer;
    private Object poof;
    private bool poofed;
    private GameObject poofclone;
    private float timerTime=9;
    
    void Start()
    {
        poofed = true;
        poof = Resources.Load("poof");
    }
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= timerTime-.5 && poofed)
        {
            poofclone = (GameObject)Instantiate(poof, transform.GetChild(0).GetChild(0).position , transform.GetChild(0).GetChild(0).rotation);
            poofed = false;
            poofclone.AddComponent<PoofDestroy>();
        }
        if (timer >= timerTime)
        {
            Destroy(gameObject);
        }
    }
}

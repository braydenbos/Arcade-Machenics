using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofDestroy : MonoBehaviour
{
    private float timer;
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= 2)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScriptTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print("Hit Water Surface");
        PlayerPrefs.SetInt("WaterHit", 1);
        gameObject.SetActive(false);
    }
}

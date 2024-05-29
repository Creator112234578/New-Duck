using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    public Boss Bosssss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    public void OnTriggerEnter(Collider Col)
    {
           if (Col.tag == "Player")
           {
              Bosssss.Cutscene = true;
           }
    }
}

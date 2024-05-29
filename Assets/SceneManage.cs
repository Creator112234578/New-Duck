using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    public string SN;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SN);
    }
}

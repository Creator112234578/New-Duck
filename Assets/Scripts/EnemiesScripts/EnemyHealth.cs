using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float HP;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator EnemyDamaged(int damageAmount)
    {
        HP -= damageAmount;
        yield return new WaitForSeconds(1f);
    }
}

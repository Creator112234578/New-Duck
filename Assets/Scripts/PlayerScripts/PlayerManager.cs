using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static float playerHP;
    public static bool isGameOver;
    public TextMeshProUGUI playerHPText;
    public GameObject bloodOverlay;
    public Slider healthSlider;
    public Slider easeSlider;
    public float maxHealth;
    public float lerpHealth;
    void Start()
    {
        isGameOver = false;
        playerHP = 100;        
    }
    // Update is called once per frame
    void Update()
    {
        playerHPText.text = "" + playerHP;
        if (isGameOver)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (healthSlider.value != playerHP)
        {
           healthSlider.value = playerHP;
        }
        if (healthSlider.value != easeSlider.value)
        {
            easeSlider.value = Mathf.Lerp(easeSlider.value, playerHP, lerpHealth);
        }
    }
    public IEnumerator Damage (int damageAmount)
    {
        bloodOverlay.SetActive(true);
        playerHP -= damageAmount;
        if (playerHP <= 0)
            isGameOver = true;
        yield return new WaitForSeconds(1f);
        bloodOverlay.SetActive(false);
    }
}

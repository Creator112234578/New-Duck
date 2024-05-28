using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public Transform rotatingThing;
    public Transform Enemy;
    public GameObject Rocket;
    public Transform Spawner;
    public bool AbleToAttack;
    public bool ChangeBehavior;
    public bool UpGo;
    public float Y;
    public Rigidbody rb;
    public Transform Model;
    public Transform PlayerTransform;
    public Transform GoHere;
    public bool Chased;
    public bool Helicopter;
    public bool Attacks;
    public bool Cutscene;
    public float Health;
    public GameObject BossGameObject;
    public Slider healthSlider;
    public Slider easeSlider;
    public GameObject healthSliderObj;
    public GameObject easeSliderObj;
    public GameObject backgroundSliderObj;
    public float maxHealth;
    public float lerpHealth;
    void Start()
    {
        UpGo = false;
        healthSliderObj.SetActive(false);
        easeSliderObj.SetActive(false);
        backgroundSliderObj.SetActive(false);
        Y = transform.position.y + 9.75f;
        Chased = false;
        transform.position = GoHere.position;
        Health = maxHealth;
        Cutscene = false;
        ChangeBehavior = true;
        Helicopter = false;
    }
    void Update()
    {
        if (healthSlider.value != Health)
        {
            healthSlider.value = Health;
        }
        if (healthSlider.value != easeSlider.value)
        {
            easeSlider.value = Mathf.Lerp(easeSlider.value, Health, lerpHealth);
        }
        if (Health <= 0)
        {
            BossGameObject.SetActive(false);
        }
        if (Cutscene == true)
        {
            Active();
        }
        if (Cutscene == true & Health > 0)
        {
            healthSliderObj.SetActive(true);
            easeSliderObj.SetActive(true);
            backgroundSliderObj.SetActive(true);
        }
        else
        {
            healthSliderObj.SetActive(false);
            easeSliderObj.SetActive(false);
            backgroundSliderObj.SetActive(false);
        }
    }
    void Rotate()
    {
         if (transform.position.y < Y)
         {
             Enemy.Translate(Vector3.up * 7.5f * Time.deltaTime);
             Enemy.Translate(Vector3.back * 7.5f * Time.deltaTime);
         }
         else
         {
             rotatingThing.Rotate(0f, 0.5f, 0f);
         }
    }
    void Chase()
    {
         if (AbleToAttack == true)
         {
            rb.AddForce(Vector3.down * 2.5f, ForceMode.Impulse);
         }  
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    void AttacksChangeFunction()
    {
         Attacks = true;
         transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
         ChangeBehavior = false;
         Invoke(nameof(ACF), 14);
    }
    void Shoot()
    {
         Instantiate(Rocket, Spawner.position, Spawner.rotation);
         AbleToAttack = false;
         Invoke(nameof(Attack), 5);
    }
    void BoolEnable()
    {    
         ChangeBehavior = true;
    }
    void ACF()
    {    
         Attacks = false;
         Invoke(nameof(BoolEnable), 14);
    }
    void Up()
    {
         UpGo = true;
         Model.LookAt(GoHere);
         AbleToAttack = false;
         Invoke(nameof(Attack2), 0.5f);
    }
    void Attack()
    {
         AbleToAttack = true;
    }
    void CutsceneScaryStare()
    {
         if (transform.position.y < Y & Cutscene == true)
         {
            Enemy.Translate(Vector3.up * 5.5f * Time.deltaTime);
            Model.LookAt(PlayerTransform);
         }
         else if (transform.position.y >= Y)
         {
            Active();
            Cutscene = false;
         }
    }
    void Active()
    {
        if (Attacks == true)
        {
           rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
           Helicopter = true;
           Chased = false;
        }
        if (Attacks == false)
        {
           rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
           Chased = true;
           Helicopter = false;
        }
        if (Helicopter == true)
        {
           rb.velocity = new Vector3(0, 0, 0);
           Rotate();
           if (AbleToAttack == true)
           {
              Shoot();
           }
        }
        if (Chased == true)
        {
           if (UpGo == true)
           {
            
              rb.AddForce(Vector3.up * 7.5f, ForceMode.Force);
            
           }
           Chase();
        }
        if (ChangeBehavior == true)
        {
           AttacksChangeFunction();
        }
    }
    void Attack2()
    {
         UpGo = false;
         AbleToAttack = true;
    }
    private void OnCollisionEnter(Collision Col)
    {
         if (Chased == true & Col.gameObject.layer == 6)
         {
            transform.position = new Vector3(GoHere.transform.position.x, GoHere.transform.position.y, GoHere.transform.position.z);
            Up();
         }
         if (Chased == true & Col.gameObject.layer == 7)
         {
            transform.position = new Vector3(GoHere.transform.position.x, GoHere.transform.position.y, GoHere.transform.position.z);
            Up();
         }
    }
}

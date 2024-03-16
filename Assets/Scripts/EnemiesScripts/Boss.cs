using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform rotatingThing;
    public Transform Enemy;
    public GameObject Wee;
    public Transform Spawner;
    public bool AbleToAttack;
    public bool ChangeBehavior;
    public bool UpGo;
    public float Y;
    public Rigidbody rb;
    public Transform Model;
    public RaycastHit Player;
    public Transform GoHere;
    public LayerMask layer;
    public bool Chased;
    public bool Helicopter;
    public int Attacks;
    
    
    void Start()
    {
        UpGo = false;
        Y = transform.position.y + 9.75f;
        Chased = false;
        transform.position = GoHere.position;
        ChangeBehavior = true;
        Helicopter = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Attacks == 1)
        {
           Helicopter = true;
           Chased = false;
        }
        if (Attacks == 2)
        {
           Chased = true;
           Helicopter = false;
        }
        if (Helicopter == true)
        {
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
    void AttacksChangeFunction()
    {
         Attacks = Random.Range(1,2);
         ChangeBehavior = false;
         Invoke(nameof(BoolEnable), 0.5f);
    }
    void Shoot()
    {
         Instantiate(Wee, Spawner.position, Spawner.rotation);
         AbleToAttack = false;
         Invoke(nameof(Attack), 5);
    }
    void BoolEnable()
    {
         ChangeBehavior = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This will Dictate Stats like health and attack, NOT fighting
public class Stats : MonoBehaviour
{
    [SerializeField]
    private int iHealth, iMaxHealth = 100; //Health and Max health
    [SerializeField]
    private int iBlood =0, iMaxBlood = 1000;
    [SerializeField]
    private int iAtk = 5;
    private int iDef = 0;
    [SerializeField]
    private int iJumpspeed;
    [SerializeField]
    private int iMovespeed, speedcap = 6;

    public int pubJumpSpeed
    {
        get { return iJumpspeed; }
    }
    public int pubSpeed
    {
        get { return iMovespeed; }
    }
    public int pubSpeedCap
    {
        get { return speedcap; }
    }
    public int pubAtk
    {
        get { return iAtk; }
    }
    public float hperc()
    {
        return ((float)iHealth / (float)iMaxHealth);
    }

    public float bperc()
    {
        return ((float)iBlood / (float)iMaxBlood);
    }

    public int pubBlood
    {
        get { int tempblood = iBlood/25;  iBlood = 0; return tempblood; }
    }
    public bool isDead()
    {
        if (iHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public delegate void Damage(int val,float perc,Transform unit);  //The method I want to see
    public static event Damage Damaged;


    public delegate void Death(Transform unit);
    public static event Death JustDied;

    public delegate void BloodChange(int val, float perc, Transform unit);
    public static event BloodChange ChangeOfBlood;

    public delegate void Knockback(int val, Vector3 dir, Transform unit);
    public static event Knockback KnockBacked;

    //Private List Status Seffects // This will be for the end
    private void Awake()
    {
      
        iHealth = iMaxHealth; //Sets max
                
    }
    void Start()
    {
        RaiseBloodChange(0, bperc(), transform);
        RaiseInflictDamage(0, hperc(), transform);
    }
    void OnEnable()
    {
        Damaged += InflictDamage;
        JustDied += DeathFlag;
        ChangeOfBlood += ChangeBlood;
        KnockBacked += Knockedback;
    }
    void OnDisable()
    {
        Damaged -= InflictDamage;
        JustDied -= DeathFlag;
        ChangeOfBlood -= ChangeBlood;
        KnockBacked -= RaiseKnockUnitBack;
    }

    void Knockedback(int val, Vector3 dir, Transform unit)
    {
        if (unit.name == this.name)
        {

            KnockbackForce(val, dir);
        }
    }
    public void KnockbackForce(int str, Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir * str, ForceMode.Impulse);
    }


    void ChangeBlood(int val, float perc, Transform unit)
    {
        
        if (unit.name == this.transform.name && perc < 1f)
        {
            iBlood += val;
            if (iBlood < 0)
            {
                iBlood = 0;
            }
            else if (iBlood > iMaxBlood)
            {
                iBlood = iMaxBlood;
            }
        }

    }


    public void OnTriggerEnter(Collider other)
    {
        //On entering blood
        if (other.tag == "Blood")
        {
            //All Units take 5 damage
            RaiseInflictDamage(5,hperc(),transform);
            //All Units gain 5 blood points
           // RaiseBloodChange(5, bperc(), transform);
        }
        if (other.tag == "Trap")
        {
            RaiseInflictDamage(20, hperc(), transform);
            RaiseBloodChange(60, bperc(), transform);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Blood")
        {
            RaiseInflictDamage(1, hperc(), transform);
            //RaiseBloodChange(1, bperc(), transform);
        }
    }

    
    void InflictDamage(int val, float perc, Transform unit)
    {
       
        if (unit.name == this.name)
        {
            iHealth -= Mathf.Max(val-iDef,1);
            Debug.Log("I," + name +" took " + Mathf.Max(val - iDef, 1) + "damage");
            if ( (iBlood/iMaxBlood) > 0.75f)
            {
                int tempblood = iBlood;
                // ChangeBlood(-99999, bperc(), transform);
                iBlood = 0;
                Debug.Log("Spawning from " + unit);
                ChangeBlood(0, bperc(), transform);
                BloodWell.RaiseBloodSummoning(tempblood, transform.position);

            }

            if (iHealth <=0)
            {
                RaiseDeathCheck(transform);
            }
        }
    }


    void DeathFlag(Transform unit)
    {
        Debug.Log(unit.name);
        if (unit.name == this.name)
        {
            Destroy(unit.gameObject, 3);
        }
        else
        {

        }
    }

    public static void RaiseBloodChange(int val, float perc, Transform unit)
    {
        ChangeOfBlood?.Invoke(val,perc,unit);
    }

    public static void RaiseKnockUnitBack(int val, Vector3 dir,Transform unit)
    {
        KnockBacked?.Invoke(val, dir, unit);
    }

    public static void RaiseInflictDamage(int val, float perc,Transform unit)
    {
        //Called Externally

        Damaged?.Invoke(val,perc,unit);
    }


    public static void RaiseDeathCheck(Transform unit)
    {
        JustDied?.Invoke(unit);
    }

}

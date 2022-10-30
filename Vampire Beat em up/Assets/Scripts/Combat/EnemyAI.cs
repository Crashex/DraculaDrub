using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    private delegate void PlayerNear(Collider other);
    private event PlayerNear Wakeup;

    [SerializeField]
    private Stats Player,statMe;
    [SerializeField]
    private NavMeshAgent me;
    [SerializeField]
    private SphereCollider Checkcollider;
    [SerializeField]
    private BoxCollider AttackBox;
    private SpriteManagement Myanim;
    private SpriteManagement spriteanim;
    

    /*
     * Enemy Sleeps
     * Player gets in range
     * Enemy Wakes up
     * Enemy Walks to Player when out of Range
     * When in Range it tries to hit the Player
     * If the Enemy is Hit, the Enemy is stunned for a little bit.
     * When the Enemy is dead, the Enemy stops trying to attack
     */
    private void RaiseWakeup(Collider other)
    {
        Wakeup?.Invoke(other);
    }

    void start()
    {
        me.speed = statMe.pubSpeed;
    }

    void OnEnable()
    {
        Wakeup += AIRoutine;
    }
    void OnDisable()
    {
        Wakeup -= AIRoutine;
    }
    
    void OnTriggerEnter(Collider other)
    {
        RaiseWakeup(other);
    }
    
    public void AIRoutine(Collider other)
    {
        if (other.tag == "Player")
        {
          
            Player = other.GetComponent<Stats>();
            Checkcollider.enabled = false;
            StartCoroutine(AIProcess());
            Wakeup -= AIRoutine; //Because the Player already woke the AI up
        }
        else
        {
          
        }
    }

    private void Attack()
    {
        Collider[] things = Physics.OverlapBox(AttackBox.transform.position + AttackBox.center, AttackBox.size, Quaternion.identity);
        Stats player;
        foreach (Collider item in things)
        {

            if (item.tag == "Player")
            {
                player = item.GetComponent<Stats>();
                Stats.RaiseInflictDamage(statMe.pubAtk, player.hperc(), player.transform);
                Stats.RaiseBloodChange(31, player.bperc(), player.transform);
            }
        }

    }

    public IEnumerator AIProcess()
    {
        while (statMe.isDead() == false)
        {
            
            if (Vector3.Distance(transform.position, Player.transform.position) > 3)
            {
                me.SetDestination(Player.transform.position);
                yield return new WaitUntil(()=> me.remainingDistance <5);
               
                continue;
            }
            else
            {
              
                Attack();
                yield return new WaitForSeconds(1);
                
                continue;
            }
            

        }
    }




}

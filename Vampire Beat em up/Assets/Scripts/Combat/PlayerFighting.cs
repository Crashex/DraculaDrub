using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFighting : MonoBehaviour
{
    [SerializeField]
    BoxCollider boxAttack;
    [SerializeField]
    Stats mystats;
    [SerializeField]
    int combo = 0;
    [SerializeField]
    private PlayerInputManager inputmanager;
    [SerializeField]
    private SpriteManagement smplayer;
    [SerializeField]
    private SpriteManagement effects;
    [SerializeField]
    bool attacking, attackqueued;
    

    public bool pubatking
    {
        get { return attacking; }
    }
    // Start is called before the first frame update
    public void EXStart()
    {
        SetupCombat();
    }


    void SetupCombat()
    {
        inputmanager.playeractions = inputmanager.playercontrols.Combat;
        inputmanager.playeractions.Attack.performed += _ => AttackManager();
        StartCoroutine(Attackburnout());
    }
    
    void Attack()
    {
        Debug.Log("HYAH");
        effects.spritePlay(0, inputmanager.flipped,0.4f);
        inputmanager.pubpm.StopVelo();
        inputmanager.BChangeMoveTimed(false, 0.5f);
        StartCoroutine(DamageDelay(0.2f));
    
    }

    IEnumerator Attackburnout()
    {
        while (true)
        {
            if (attacking == false && attackqueued == false)
            {
                combo = 0; //Player not attacking
            }
            else if (attacking == false && attackqueued == true)
            {
                AttackManager();
                attackqueued = false;
               
                
                //Auto Attack
            }
            else if (attacking == true && attackqueued == true)
            {

            }
            else
            {

            }
            yield return new WaitForEndOfFrame();
        }
    }
    void Attack(float hitDelay,float moveDelay)
    {
        attacking = true;
        Debug.Log("HYAH");
        effects.spritePlay(0, inputmanager.flipped, 0.4f);
        inputmanager.pubpm.StopVelo();
        inputmanager.BChangeMoveTimed(false, moveDelay);
        StartCoroutine(DamageDelay(hitDelay));
        StartCoroutine(AttackTimeout(0.3f));
    }

    IEnumerator AttackTimeout(float dur)
    {
        yield return new WaitForSeconds(dur);
        attacking = false;
        smplayer.spritePlay(0, inputmanager.flipped, 0.1f);
    }
    void AttackManager()
    {
        if (attacking != true )
        {
            Debug.Log(combo);
            switch (combo)
            {
                case (0):
                    {
                        Attack(0.2f, 0.85f);
                        smplayer.spritePlay(1, inputmanager.flipped, 0.5f); //0 means it doesn't disable the sprite
                        break;
                    }
                case (1):
                    {
                        Attack(0.2f, 0.85f);
                        smplayer.spritePlay(5, inputmanager.flipped, 0.5f); //0 means it doesn't disable the sprite
                        break;
                    }
                case (2):
                    {
                        Attack(0.2f, 0.75f);
                        Attack(0.3f, 0.9f);
                        smplayer.spritePlay(6, inputmanager.flipped, 0.7f);
                        break;
                    }
                case (3):
                    {
                        Attack(0.2f, 0.75f);
                        smplayer.spritePlay(5, inputmanager.flipped, 0.5f);
                        break;
                    }
                default:
                    {
                        Attack(0.4f, 1f);
                        smplayer.spritePlay(1, inputmanager.flipped, 1f);
                        combo = -1;
                        attackqueued = false;
                        
                        break;
                    }
            }
            combo++;
        }
        else
        {
            attackqueued = true;
        }

    }
    private IEnumerator DamageDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DamageCheck();
    }
    void DamageCheck()
    {
        int flipmod = -1;
        if (inputmanager.pubpm.isflipped == true)
        {
            flipmod = 1;
        }


        Collider[] things = Physics.OverlapBox(boxAttack.transform.position + ( flipmod * boxAttack.center), boxAttack.size, Quaternion.identity);
        Stats enemy;
        foreach (Collider thing in things)
        {
            if (enemy = thing.GetComponent<Stats>())
            {
                if (enemy.tag == "Enemy")
                {
                   
                    Stats.RaiseInflictDamage(mystats.pubAtk, enemy.hperc(), enemy.transform);
                    Stats.RaiseBloodChange(31, mystats.bperc(), this.transform);
                    Vector3 kb= new Vector3(enemy.transform.position.x - this.transform.position.x, 0, enemy.transform.position.z - this.transform.position.z);
                    Stats.RaiseKnockUnitBack(Random.Range(1,5),kb,enemy.transform);

                }
            }


        }
    }
}

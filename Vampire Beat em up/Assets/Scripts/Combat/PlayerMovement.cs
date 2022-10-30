using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SPCombat;
using DigitalRuby.Tween;

//This will dictate movement, NOT ACTION
[RequireComponent(typeof(Stats))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Stats myStats;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private PlayerInputManager inputmanager;
    [SerializeField]
    private SpriteManagement sm;
    [SerializeField]
    private BoxCollider feets;

    // Start is called before the first frame update

    [SerializeField]
    private bool bjumped = false, bcontrol = true, flip = false,dashing = false;

    public bool combatControl
    {
        get { return bcontrol; }
        set { bcontrol = value; }
    }

    public bool isflipped
    {
        get { return flip; }
    }

    public void StopVelo()
    {
        rb.velocity = Vector3.zero;
    }

    private IEnumerator Timeout(float dir)
    {
        bcontrol = false;
        yield return new WaitForSeconds(dir);
        bcontrol = true;
    }

    void OnEnable()
    {
        Stats.JustDied += PlayerDeath(this.transform);
    }
    void OnDisable()
    {
        Stats.JustDied -= PlayerDeath(this.transform);
    }

    Stats.Death PlayerDeath(Transform unit)
    {
        if (unit.name == this.transform.name)
        {
            bcontrol = false;
            bjumped = false;
        }
        return null;
    }


    public void EXStart()
    {
      if (myStats == null)
        {
            myStats = GetComponent<Stats>();
            
        }


        if (inputmanager.player == null)
        {
            inputmanager.player = GameObject.Find("Brain").GetComponent<PlayerInput>();
            inputmanager.playercontrols = new PlayerControls();
            
        }
        SetActions();

    }



    void SetActions()
    {

        inputmanager.playeractions = inputmanager.playercontrols.Combat;
        inputmanager.playeractions.Enable();
        inputmanager.playeractions.Jump.canceled += _ => Jump();
        inputmanager.playeractions.Dash.performed += _ => Dash();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myStats.isDead() == false)
        {
            Movement(inputmanager.playeractions.Move.ReadValue<Vector2>());
            //  inputmanager.playeractions.Move.ReadValue<Vector2>();
            DetectGround();
        }
    }


    void Movement(Vector2 move)
    {

        if (bcontrol == true && bjumped == false)
        {
            if (move == Vector2.zero)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                if (inputmanager.pubpf.pubatking == false && bjumped == false && bcontrol == true )
                {
                    sm.spritePlay(0, isflipped, 0);
                }
            }
            else if (move != Vector2.zero && bjumped == false)
            {
                sm.spritePlay(2, isflipped, 2);

                move = move.normalized; //if flipped
                if (move.x > 0.1f)
                {
                    flip = true;


                }
                else if (move.x < -0.1f)
                {
                    flip = false;

                    //If moving left
                }
                
                rb.AddForce(new Vector3(move.x * myStats.pubSpeed, 0, move.y * myStats.pubSpeed));//move * myStats.pubSpeed);
                Speedcap(rb.velocity);
            }
           
        }

    }


    void Speedcap(Vector3 speed)
    {
        if (speed.x > myStats.pubSpeedCap)
        {
            speed.x = myStats.pubSpeedCap;
        }
        if (speed.x < -myStats.pubSpeedCap)
        {
            speed.x = -myStats.pubSpeedCap;
        }
        if (speed.z > myStats.pubSpeedCap)
        {
            speed.z = myStats.pubSpeedCap;
        }
        if (speed.z < -myStats.pubSpeedCap)
        {
            speed.z = -myStats.pubSpeedCap;
        }
        rb.velocity = new Vector3(speed.x, rb.velocity.y, speed.z);
    }

    void Jump()
    {
        if (bjumped == false && bcontrol == true)
        {
            bjumped = true;
            bcontrol = false;
            //sm.spritePlay(3, flip, 2f);
            rb.velocity = new Vector3(rb.velocity.x * 0.85f, rb.velocity.y, rb.velocity.z * 1.75f);
            rb.AddForce(Vector3.up * myStats.pubJumpSpeed, ForceMode.VelocityChange);


        }

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawCube(feets.transform.position, feets.size);
    }

    private void DetectGround()
    {
        if (dashing == true)
        {
            return;
        }
        RaycastHit hit;
        Physics.Raycast(feets.transform.position, Vector3.down, out hit, 2f);

        for (int i= -1;i < 2;i++)
        {
            //Left check, middle check, right check
            Physics.Raycast(feets.transform.position + Vector3.right * i, Vector3.down , out hit, 2f);
            if (hit.transform != null)
            {
                
            }
        }
       // Physics.BoxCast(feets.transform.position, feets.size, Vector3.down, out hit,Quaternion.identity,0.5f);


        if (hit.transform != null && hit.transform.tag == "Ground" && rb.velocity.y <= 0)
        { //There's ground, and velocity is either downward or 0
            bcontrol = true;
            bjumped = false;

        }
        else if (hit.transform != null && rb.velocity.y > 0)
        {
            bjumped = true;
            bcontrol = false;
            return;

        }
        else if (hit.transform == null && rb.velocity.y <= 0)
        {
            rb.velocity += new Vector3(0, -0.4f, 0);
        }
        else
        {

        }


    }

    void Dash()
    {
        if (bcontrol == true)
        {
            dashing = true;
            Vector3 dir = new Vector3(inputmanager.playeractions.Move.ReadValue<Vector2>().x, 0, inputmanager.playeractions.Move.ReadValue<Vector2>().y);
            bcontrol = false;
            StartCoroutine(Timeout(0.3f));
            StartCoroutine(Dashing(dir));

        }
    }

    private IEnumerator Dashing(Vector3 move)
    {
        
        Vector3 startpos = transform.position;
        Vector3 endpos = transform.position + move * 4;
        sm.spritePlay(5, flip, 0.15f);
        System.Action<ITween<Vector3>> play = (t) =>
        {
            transform.position = t.CurrentValue;
        };
        TweenFactory.Tween(this.gameObject, startpos, endpos, 0.15f, TweenScaleFunctions.Linear, play);
        yield return new WaitForSeconds(0.15f);
        dashing = false;
        if (bjumped == false)
        {
            bcontrol = true;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}

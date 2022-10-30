using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPCombat;
using UnityEngine.InputSystem;
public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInput myinput;
    [SerializeField]
    private PlayerControls PC;
    [SerializeField]
    private PlayerControls.CombatActions myactions;
    [SerializeField]
    private PlayerFighting pf;
    [SerializeField]
    private PlayerMovement pm;


    public bool flipped { get { return pm.isflipped; } }

    public PlayerMovement pubpm
    { get { return pm; } }

    void Start()
    {
        pm.EXStart();
        pf.EXStart();
    }


    public void BChangeMove(bool newvalue)
    {
        pm.combatControl = newvalue;
    }
    public void BChangeMoveTimed(bool newvalue, float duration)
    {//True means can move, false means can't move
        pm.combatControl = newvalue;
        StartCoroutine(timer(duration, !newvalue));
    }
    private IEnumerator timer(float duration, bool returnvalue)
    {
        yield return new WaitForSeconds(duration);
        BChangeMove(returnvalue);
    }

    public PlayerInput player
    {
        get { return myinput; }
        set { myinput = value; }
    }
    public PlayerFighting pubpf
    {
            
            get { return pf; }
            
            set { pf = value; }
    }

    public PlayerControls playercontrols
    {
        get { return PC; }
        set { PC = value; }
    }
    public PlayerControls.CombatActions playeractions
    {
        get { return myactions; }
        set { myactions = value; }
    }
    // Start is called before the first frame update
}

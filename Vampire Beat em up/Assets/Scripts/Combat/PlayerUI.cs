using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    Stats statsPlayer;

    [SerializeField]
    Image healthBar;
    [SerializeField]
    Image secondBar;

    [SerializeField]
    Image enemyHPBar;
    // Start is called before the first frame update
    void Start()
    {
        if (statsPlayer!= null)
        {

        }
        else
        {
            this.enabled = false;
        }
    }


    void OnHealthChange(int val, float perc, Transform unit)
    {
            HPBarUpdate(true, perc, unit);
    }


    void OnBloodChange(int val, float perc, Transform unit)
    {
        HPBarUpdate(false, perc, unit);
    }
    void OnEnable()
    {
        
        Stats.Damaged += OnHealthChange;
        Stats.ChangeOfBlood+= OnBloodChange;
    }
    void OnDisable()
    {
        Stats.Damaged -= OnHealthChange;
        Stats.ChangeOfBlood -= OnBloodChange;
    }

  

    public Stats.Damage HPBarUpdate(bool hp,float barperc,Transform unit)
    {

        Image refBar = healthBar;
        switch (unit.tag)
        {
            case ("Player"):
                {
                    switch (hp)
                    {
                        case (true):
                            {
                                refBar = healthBar;
                                break;
                            }
                        case (false):
                            {
                                refBar = secondBar;
                                break;
                            }
                    }
                                
                    break;
                }
            case ("Enemy"):
                {
                    switch(hp)
                    {
                        case (true):
                            {
                                refBar = enemyHPBar;
                                break;
                            }
                        case (false):
                            {
                                refBar = null;
                                break;
                            }

                    }

                    break;
                }
            default:
                {
                    refBar = null;
                    break;
                }
        
        }




        if (refBar != null)
        {
            refBar.fillAmount = barperc;
        }
        
        
        return null;

    }
}

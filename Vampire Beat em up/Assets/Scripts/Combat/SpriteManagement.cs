using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManagement : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private List<Sprite> lstSprites;
    private enum SpriteType { Sprite,Effect }
    [SerializeField]
    private SpriteType mytype;


    private void Update()
    {
        if (mytype == SpriteType.Sprite)
        {
            sr.transform.LookAt(Camera.main.transform.position);
        }
    }
    public void spritePlay(int sprite,bool flipped,float time)
    {
        Vector3 srpos = sr.transform.localPosition;
        srpos.x = Mathf.Abs(srpos.x); //Sr position is default facing right
        sr.flipX = flipped; //True is flipped, false is right facing

        Debug.Log("Starting " + lstSprites[sprite]);



        if (sr.flipX == false)
        {

                srpos.x *= -1;
            //If flip is true, flip position
   
        }
        sr.transform.localPosition = srpos;
        if (sprite == -1)
        {
            sr.sprite = null;
        }
        else
        {
            sr.sprite = lstSprites[sprite];
        }
        if (time != 0)
        {
            time =  Mathf.Abs(time);
            StartCoroutine(timer(time));
        }
    }

    private IEnumerator timer(float time)
    {
        yield return new WaitForSeconds(time);
        if (mytype == SpriteType.Effect)
        {
            sr.sprite = null;
        }
        yield return null;
    }

}

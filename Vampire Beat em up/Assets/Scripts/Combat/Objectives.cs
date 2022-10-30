using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objectives : MonoBehaviour
{
    public delegate void LevelFinished();  //The method I want to see
    public static event LevelFinished AtEnd;

    public int nextscene = 2;

    public Stats Player;
    public Transform EndGoal;


    public void ExtLoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    void OnEnable()
    {
        AtEnd += Objectives_AtEnd;
    }

    void OnDisable()
    {
        AtEnd -= Objectives_AtEnd;
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(ObjectiveCheck());
    }

    private void Objectives_AtEnd()
    {
        StartCoroutine(LevelTransition());
    }

    private void RaiseOnLevelEnd()
    {
        AtEnd?.Invoke();
    }
    private IEnumerator LevelTransition()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(nextscene);
    }


    private IEnumerator ObjectiveCheck()
    {
        float dis = Vector3.Distance(Player.transform.position, EndGoal.transform.position);
        while ( true)
        {
            dis = Vector3.Distance(Player.transform.position, EndGoal.transform.position);

            if (dis< 5)
            {

                RaiseOnLevelEnd();
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}

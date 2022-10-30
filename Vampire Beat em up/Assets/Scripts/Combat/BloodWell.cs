using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodWell : MonoBehaviour
{
    [SerializeField]
    private GameObject BloodPrefab;


    public delegate void SummonBlood(int intensity, Vector3 location);  //The method I want to see
    public static event SummonBlood Summoning;


    void OnEnable()
    {
        Summoning += BloodWell_Summoning;
    }

    private void BloodWell_Summoning(int intensity, Vector3 location)
    {
        GameObject sample = Instantiate(BloodPrefab, location+Vector3.down, Quaternion.identity);
        sample.transform.localScale = new Vector3(intensity/25, 1, intensity/25);
        GameObject.Destroy(sample, 2);
    }


    public static void RaiseBloodSummoning(int intensity, Vector3 location)
    {
        Summoning?.Invoke(intensity,location);
    }

    // Start is called before the first frame update

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using SPCombat;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class ConversationController : MonoBehaviour
{
    public GameObject ActorHolder;
    [SerializeField]
    private List<GameObject> Actors;
    public TextMeshProUGUI Textbox;
    public TextMeshProUGUI Namebox;
    [SerializeField]
    private TextAsset asset;
    private string[] text;
    private int line = 0;
    [SerializeField]
    private PlayerInput pi;
    [SerializeField]
    private PlayerControls pc;
    private enum Converaction { Stay,Forward,Backward,Skip};
    [SerializeField]
    private Converaction myaction = Converaction.Stay;
    [SerializeField]
    private PlayerControls.CutsceneActions ca;


    [SerializeField]
    private int nextscene = 0;
    // Start is called before the first frame update
    void Start()
    {
        pc = new PlayerControls();
        ca = pc.Cutscene;

       // Debug.Log(pc +" "+ ca);
        text = asset.ToString().Split('\n');

        ca.Enable();
        ca.Advance.performed+= _ => StoryDir(1); //Forward
        ca.BackTrack.performed += _ => StoryDir(2); //Back one
        ca.Skip.performed += _ => test();// StoryDir(3); //Skip


        for (int i = 0; i < ActorHolder.transform.childCount;i++)
        {
            Actors.Add(ActorHolder.transform.GetChild(i).gameObject);
        }
        StartCoroutine(storyprocess());
    }


    
    private void test()
    {
        Debug.Log("Fudge");
    }
    private void StoryDir(int dir)
    {
        Debug.Log("Oh yeah " + dir);
        myaction = (Converaction)dir;
    }
    
    // Update is called once per frame

    private IEnumerator storyprocess()
    {

        while (line < text.Length)
        {
            readline();
            line++;
            yield return new WaitUntil(()=>myaction != Converaction.Stay);
            switch (myaction)
            {
            case(Converaction.Forward):
                    {
                        break;
                    }
                case (Converaction.Backward):
                    {
                        line-=2;
                        if (line < 0)
                        {
                            line = 0;
                        }
                        break;
                    }
                case (Converaction.Skip):
                    {
                        line = 99999;
                        break;
                    }
            }

        }
        SceneManager.LoadScene(nextscene);
    }


    void IsTalking(bool talking, Image sr)
    {
        switch(talking)
        {
            case (true):
                {
                    sr.color = Color.white;
                    break;
                }
            case (false):
                {
                    sr.color = Color.grey;
                    break;
                }
        }
    }


    void ShowSpeaker(string speakername)
    {

        foreach (GameObject speaker in Actors)
        {
            if (speaker.name != speakername)
            {
              Debug.Log(speakername + " is not " + speaker.name);
                IsTalking(false, speaker.GetComponentInChildren<Image>());
            }
            else if (speaker.name == speakername)
            {
                Debug.Log(speakername + " is speaking");
                IsTalking(true, speaker.GetComponentInChildren<Image>());
            }
        }
    }
    void readline()
    {
        string[] myline = text[line].Split('|');
        Namebox.text = myline[0];
        Textbox.text = myline[1];
        ShowSpeaker(myline[0]);
        myaction = Converaction.Stay;
    }
}

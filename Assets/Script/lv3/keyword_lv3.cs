using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class keyword_lv3 : MonoBehaviour
{

    //LIST LETTER OF ALIEN MESSAGE
    List<string> listfirst = new List<string> { "C", "A", "N", "SPACE", "W", "E","SPACE", "T", "A", "L", "K" };
    public static List<string> list = new List<string> { "S", "U", "R", "E" };

    //--------------------------------------------------------------------------------------

    //LIST LETTER OF HUMAN MESSAGE
    public static List<string> humanMessage = new List<string> { "S", "U", "R", "E" };
    public static List<string> humanMessage1 = new List<string>();
    //--------------------------------------------------------------------------------------

    //PUBLIC STATIC VARIABLE
    public static List<string> keywordList = new List<string>();
    public static int variable = 0;

    //--------------------------------------------------------------------------------------

    //RANDOM LIBRARY
    System.Random ran = new System.Random();


    //--------------------------------------------------------------------------------------

    //OBJECT TEXT UI
    public GameObject humanMessage_back;
    public GameObject humanMessage_front;
    public GameObject alienMessage;
    public GameObject countDownTime;
    GameObject letter;
    GameObject lightLetter;
    public Material newMaterialRef;
    public Material oldMaterialRef;

    //--------------------------------------------------------------------------------------

    //SOME VAR
    string alienMessage1 = "";
    private float timeLeft = 20.0f;
    //public static string humanMessage1 = "";
    public GameObject humanchatBox;
    GameObject Button1;
    GameObject Button2;
    GameObject Button3;
    GameObject Button4;

    public static bool started = false;

    public static int checkHumanMessage = 0;
    // public event OnVariableChangeDelegate OnVariableChange;
    public AudioClip[] soundAlien;
    private AudioClip audiosound;
    private AudioSource audiosound1;
    IEnumerator Start()
    {
        
            humanchatBox.GetComponent<Image>().enabled = false;
       
        Button1 = GameObject.FindGameObjectWithTag("key1");
        Color q = new Color(Random.value, Random.value, Random.value, 1.0f);
        Button1.GetComponent<Renderer>().material.color = q;

        Button2 = GameObject.FindGameObjectWithTag("key2");
        Color q1 = new Color(Random.value, Random.value, Random.value, 1.0f);
        Button2.GetComponent<Renderer>().material.color = q1;
        Button3 = GameObject.FindGameObjectWithTag("key3");
        Color q2 = new Color(Random.value, Random.value, Random.value, 1.0f);
        Button3.GetComponent<Renderer>().material.color = q2;
        Button4 = GameObject.FindGameObjectWithTag("key4");
        Color q3 = new Color(Random.value, Random.value, Random.value, 1.0f);
        Button4.GetComponent<Renderer>().material.color = q3;
        yield return new WaitForSeconds(1.5f);
        audiosound1 = gameObject.AddComponent<AudioSource>();
        
        keywordList = list.OrderBy(i => ran.Next()).ToList();

        for (int i = 0; i < listfirst.Count; i++)
        {
            letter = GameObject.Find(listfirst[i]);
            lightLetter = GameObject.Find("point" + listfirst[i]);
            lightLetter.GetComponent<Light>().enabled = true;
            int result1 = string.CompareOrdinal("SPACE", listfirst[i]);
            if (result1 == 0)
            {
                listfirst[i] = " ";

            }
            alienMessage1 += listfirst[i];
            alienMessage.GetComponent<Text>().text = alienMessage1;
            letter.GetComponent<Renderer>().material = newMaterialRef;

            int sound = Random.Range(1, soundAlien.Length);

            audiosound = soundAlien[sound];

            audiosound1.clip = audiosound;
            audiosound1.Play();
            yield return new WaitForSeconds(0.3f);

            letter.GetComponent<Renderer>().material = oldMaterialRef;
            lightLetter.GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(0.3f);
        }
        humanchatBox.GetComponent<Image>().enabled = true;
        humanMessage_back.GetComponent<Text>().text = "SURE";
        started = true;
    }
    
    void Update()
    {
        if (started == true)
        {
            timeLeft -= Time.deltaTime;

            countDownTime.GetComponent<Text>().text = Mathf.RoundToInt(timeLeft).ToString();
            if (timeLeft <= 0)
            {
                GameOver();
            }
        }

        //Debug.Log(timeLeft);

    }
    private void GameOver()
    {
        humanMessage_front.GetComponent<Text>().text = "";
        humanMessage1.Clear();
        checkHumanMessage = 0;
        variable = 0;
        started = false;
        SceneManager.LoadScene(7);
    }
    public Color RandomColor()
    {
        byte red = (byte)ran.Next(1, 254);
        byte green = (byte)ran.Next(1, 254);
        byte blue = (byte)ran.Next(1, 254);

        return new Color(red, green, blue);
    }

    /*public void checkWordHumant(string check)
    {
        if(check == humanMessage[checkHumanMessage])
        {
            humanMessage1 += check;
            humanMessage_front.GetComponent<Text>().text = humanMessage1;
            checkHumanMessage++;
        }
        else
        {
            humanMessage_front.GetComponent<Text>().text = "";
        }
    }*/



}

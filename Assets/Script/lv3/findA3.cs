using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class findA3 : MonoBehaviour
{
    public GameObject humanMessage_back;
    public GameObject humanMessage_front;
    public Material newMaterialRef;
    public Material oldMaterialRef;
    public AudioClip[] soundAlien;
    private AudioClip audiosound;
    private AudioSource audiosound1;
    Animator m_Animator;
    System.Random ran = new System.Random();
    GameObject letter;
    GameObject lightLetter;
    string key = "";
    int variableOnFunction;
    int sound;
    void Start()
    {
        audiosound1 = gameObject.AddComponent<AudioSource>();
        m_Animator = gameObject.GetComponent<Animator>();

        variableOnFunction = keyword_lv3.variable;
        if (keyword_lv3.variable == keyword_lv3.list.Count - 1)
        {
            keyword_lv3.variable = keyword_lv3.list.Count - 1;
        }
        else
        {
            keyword_lv3.variable++;
        }
        sound = UnityEngine.Random.Range(1, soundAlien.Length);
    }
    void Update()
    {
        var fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount > 0)
        {
            OnMouseDown();
            fingerCount = 0;
        }
    }
    IEnumerator OnMouseDown()
    {
        if (keyword_lv3.started == true)
        {
            m_Animator.SetBool("Pressed", true);
        yield return new WaitForSeconds(0.1f);
        m_Animator.SetBool("Pressed", false);


        /*if (m_Animator.GetBool("Pressed") == false)
        {
            StartCoroutine(WaitForAnimation());
        }*/


        if (String.IsNullOrEmpty(variableOnFunction.ToString()))
        {
            variableOnFunction = keyword_lv3.variable;
            if (keyword_lv3.variable == keyword_lv3.list.Count - 1)
            {
                keyword_lv3.variable = keyword_lv3.list.Count - 1;
            }
            else
            {
                keyword_lv3.variable++;
            }
        }
        key = keyword_lv3.keywordList[variableOnFunction];
        //Debug.Log(key);
        //keyword_lv3.checkWordHumant(key);
        letter = GameObject.Find(key);
        lightLetter = GameObject.Find("point" + key);
        lightLetter.GetComponent<Light>().enabled = true;
        letter.GetComponent<Renderer>().material = newMaterialRef;


        audiosound = soundAlien[sound];

        audiosound1.clip = audiosound;
        audiosound1.Play();
        yield return new WaitForSeconds(0.8f);
        m_Animator.SetBool("Pressed", false);
        letter.GetComponent<Renderer>().material = oldMaterialRef;
        lightLetter.GetComponent<Light>().enabled = false;
        keyword_lv3.humanMessage1.Add(key);
        //Debug.Log(keyword_lv3.checkHumanMessage);
        //Debug.Log(keyword_lv3.humanMessage1[keyword_lv3.checkHumanMessage]);


        int result = string.CompareOrdinal(keyword_lv3.humanMessage1[keyword_lv3.checkHumanMessage], keyword_lv3.humanMessage[keyword_lv3.checkHumanMessage]);
        if (result == 0)
        {
            int result1 = string.CompareOrdinal("SPACE", keyword_lv3.humanMessage1[keyword_lv3.checkHumanMessage]);
            if (result1 == 0)
            {
                keyword_lv3.humanMessage1[keyword_lv3.checkHumanMessage] = " ";

            }
            //keyword_lv3.checkHumanMessage++;
            if (keyword_lv3.checkHumanMessage == keyword_lv3.humanMessage.Count - 1)
            {

                keyword_lv3.checkHumanMessage = keyword_lv3.humanMessage.Count - 1;
                humanMessage_front.GetComponent<Text>().text = "";
                keyword_lv3.humanMessage1.Clear();
                keyword_lv3.checkHumanMessage = 0;
                keyword_lv3.variable = 0;
                keyword_lv3.started = false;
                SceneManager.LoadScene(4);

            }
            else
            {
                keyword_lv3.checkHumanMessage++;
            }
            //Debug.Log(1);
            //humanMessage_front.GetComponent<Text>().text = "HAHA";
            humanMessage_front.GetComponent<Text>().text = string.Join("", keyword_lv3.humanMessage1.ToArray());
        }
        else
        {
            //Debug.Log(0);
            humanMessage_front.GetComponent<Text>().text = "";
            keyword_lv3.checkHumanMessage = 0;
            keyword_lv3.humanMessage1.Clear();
        }


        }
    }

    /*private IEnumerator WaitForAnimation()
    {
        m_Animator.SetBool("Pressed", true);
        yield return new WaitForSeconds(0.5f);
        m_Animator.SetBool("Pressed", false);
    }*/



}
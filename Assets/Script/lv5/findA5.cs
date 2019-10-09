﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class findA5 : MonoBehaviour
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
    int t;
    string y;
    string[] Alphabet = new string[22] { "A", "B", "C", "F", "G", "H", "J", "K", "L", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    void Start()
    {
        audiosound1 = gameObject.AddComponent<AudioSource>();
        m_Animator = gameObject.GetComponent<Animator>();

        variableOnFunction = keyword_lv5.variable;
        if (keyword_lv5.variable == keyword_lv5.list.Count - 1)
        {
            keyword_lv5.variable = keyword_lv5.list.Count - 1;
        }
        else
        {
            keyword_lv5.variable++;
        }
        sound = UnityEngine.Random.Range(1, soundAlien.Length);
        y = Alphabet[UnityEngine.Random.Range(0, Alphabet.Length)];
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
        if (keyword_lv5.started == true)
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
            variableOnFunction = keyword_lv5.variable;
            if (keyword_lv5.variable == keyword_lv5.list.Count - 1)
            {
                keyword_lv5.variable = keyword_lv5.list.Count - 1;
            }
            else
            {
                keyword_lv5.variable++;
            }
        }

        
        key = keyword_lv5.keywordList[variableOnFunction];
        for (int i = 0; i < variableOnFunction; i++)
        {
            int result3 = string.CompareOrdinal(key, keyword_lv5.keywordList[i]);
            if (result3 == 0)
            {
                t = 1;
                
                break;
            }


        }
        if(t == 1)
        {
            letter = GameObject.Find(y);
            lightLetter = GameObject.Find("point" + y);
        }
        else
        {
            letter = GameObject.Find(key);
            lightLetter = GameObject.Find("point" + key);
        }

        //Debug.Log(key);
        //keyword_lv5.checkWordHumant(key);


        lightLetter.GetComponent<Light>().enabled = true;
        letter.GetComponent<Renderer>().material = newMaterialRef;


        audiosound = soundAlien[sound];

        audiosound1.clip = audiosound;
        audiosound1.Play();
        yield return new WaitForSeconds(0.5f);
        m_Animator.SetBool("Pressed", false);
        letter.GetComponent<Renderer>().material = oldMaterialRef;
        lightLetter.GetComponent<Light>().enabled = false;
        keyword_lv5.humanMessage1.Add(key);
        //Debug.Log(keyword_lv5.checkHumanMessage);
        //Debug.Log(keyword_lv5.humanMessage1[keyword_lv5.checkHumanMessage]);


        int result = string.CompareOrdinal(keyword_lv5.humanMessage1[keyword_lv5.checkHumanMessage], keyword_lv5.humanMessage[keyword_lv5.checkHumanMessage]);
        if (result == 0)
        {
            int result1 = string.CompareOrdinal("SPACE", keyword_lv5.humanMessage1[keyword_lv5.checkHumanMessage]);
            if (result1 == 0)
            {
                keyword_lv5.humanMessage1[keyword_lv5.checkHumanMessage] = " ";

            }
            //keyword_lv5.checkHumanMessage++;
            if (keyword_lv5.checkHumanMessage == keyword_lv5.humanMessage.Count - 1)
            {
                keyword_lv5.checkHumanMessage = keyword_lv5.humanMessage.Count - 1;
                humanMessage_front.GetComponent<Text>().text = "";
                keyword_lv5.humanMessage1.Clear();
                keyword_lv5.checkHumanMessage = 0;
                keyword_lv5.variable = 0;
                    keyword_lv5.started = false;
                    SceneManager.LoadScene(6);

            }
            else
            {
                keyword_lv5.checkHumanMessage++;
            }
            //Debug.Log(1);
            //humanMessage_front.GetComponent<Text>().text = "HAHA";
            humanMessage_front.GetComponent<Text>().text = string.Join("", keyword_lv5.humanMessage1.ToArray());
        }
        else
        {
            //Debug.Log(0);
            humanMessage_front.GetComponent<Text>().text = "";
            keyword_lv5.checkHumanMessage = 0;
            keyword_lv5.humanMessage1.Clear();
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
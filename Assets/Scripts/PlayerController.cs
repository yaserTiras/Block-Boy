using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator Anim { get { return GetComponent<Animator>(); } }
    GameManager GManager { get { return FindObjectOfType<GameManager>(); } }
    public float MoveSpeed;
    bool TurnSide = true;
    delegate void turnDelegate();
    turnDelegate turn;
    public TMP_Text Score_Text;
    public TMP_Text HScore_Text;
    int hScore,Score;

    private void Start()
    {
        hScore= PlayerPrefs.GetInt("Hscore");
        HScore_Text.text = hScore.ToString();
    }

    void Update()
    {
        if (GManager.GameStarted)
        {
            Debug.Log("sadasdasdsadasdasdasdasdas");
            Anim.SetTrigger("Run");
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            #if UNITY_EDITOR
                 turn = TurnUnity;
            #endif
            #if UNITY_ANDROID
                  turn = TurnAndroid;
            #endif
                    turn();
        }
        if (!Physics.Raycast(transform.position, transform.up * -1))
        {
            Die();
        }

    }

    private void TurnUnity()
    {
        Debug.Log("sssssssssss");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Turn();
        }
    }
    private void TurnAndroid()
    {
        if (Input.touchCount > 0)
        {
            float xStartPos = 0;
            float XEndPos = 0;

            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    xStartPos = Input.GetTouch(0).position.x;
                    break;

                case TouchPhase.Ended:
                    XEndPos = Input.GetTouch(0).position.x;
                    if (Mathf.Abs(XEndPos - xStartPos) > 80)
                        Turn();
                    break;

            }
        }

    }
    void Die()
    {
        Anim.SetTrigger("Fall");
        if(Score>hScore)
        PlayerPrefs.SetInt("Hscore", hScore);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Crys"))
        {
            Destroy(other.gameObject);
            Score++;
            Score_Text.text = Score.ToString();
        }
            
    }

    private void Turn()
    {
        Debug.Log("sadasd");
        if (TurnSide)
        {
            transform.Rotate(0, 90, 0);
        }
        else
        {
            transform.Rotate(0, -90, 0);
        }
        TurnSide = !TurnSide;
    }
}

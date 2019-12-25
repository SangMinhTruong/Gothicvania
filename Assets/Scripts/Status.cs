using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Status : MonoBehaviour
{
    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]
    private Text healthPoints;
    //void Awake()
    //{
    //    //healthBarRect = GetComponent<Image>();
    //}
    void Start()
    {
        if (healthBarRect == null)
        {
            Debug.LogError("STATUS INDICATOR: No health bar object referenced!");
        }
        //if (healthPoints == null)
        //{
        //    Debug.LogError("STATUS INDICATOR: No health text object referenced!");
        //}
    }

    public void SetHealth(int _cur, int _max)
    {
        float _value = (float)_cur / _max;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);
        //healthPoints.text = _cur + "/" + _max + " HP";
        
    }
}

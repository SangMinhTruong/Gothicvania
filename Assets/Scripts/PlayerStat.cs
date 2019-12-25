using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public static PlayerStat instance;

    public int maxHealth = 300;
    public GameObject gameOver;
    private int _curHealth;
    [SerializeField]
    Text Points;
    public int point=0;
    public int curHealth
    {
        get { return _curHealth; }
        set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
    }

    public float healthRegenRate = 2f;

    public float movementSpeed = 10f;
    void Update()
    {
        Points.text = point.ToString();
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
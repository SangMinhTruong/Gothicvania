using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public PlayerStat playerStat;
    public bool isBoss;
    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public int damage = 25;

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public EnemyStats stats = new EnemyStats();
    private Animator myAnim;
    //public AnimationClip deathParticles;
    public Transform deathAnim;
    public float shakeAmt = 0.1f;
    public float shakeLength = 0.1f;
    AudioManager audioManager;
    //[Header("Optional: ")]
    [SerializeField]
    private Status statusIndicator;
    public Transform healthPot;
    public Transform speedPot;
    public Transform attackSpeedPot;
    public Transform attackPot;
    int dropChance = 4;
    int random;
    int potType;
    void Awake()
    {
        audioManager = AudioManager.instance;
    }
    void Start()
    {
        playerStat = PlayerStat.instance;
        myAnim = GetComponent<Animator>();
        stats.Init();
       // myAnim["deathParticles"].wrapMode = WrapMode.Once;
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
        if(isBoss)
        {
            stats.maxHealth = 1000;
            stats.damage = 50;
        }
        //if (deathParticles == null)
        //{
        //    Debug.LogError("No death particles referenced on Enemy");
        //}
    }

    public void DamageEnemy(int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            random = Random.Range(1, 5);
            if(random==dropChance)
            {
                potType = Random.Range(1, 5);
                switch(potType)
                {
                    case 1:
                        Instantiate(healthPot, transform.position, transform.rotation);
                        break;
                    case 2:
                        Instantiate(speedPot, transform.position, transform.rotation);
                        break;
                    case 3:
                        Instantiate(attackPot, transform.position, transform.rotation);
                        break;
                    case 4:
                        Instantiate(attackSpeedPot, transform.position, transform.rotation);
                        break;
                    default:
                        break;
                }
            }
            audioManager.PlaySound("Grunt");
            playerStat.point += Random.Range(300, 500);
                //GameMaster.KillEnemy(this);
                // myAnim.Play("deathParticles");
                
                Instantiate(deathAnim, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            
            
            
            
        }

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }

    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
            _player.DamagePlayer(stats.damage);
            //DamageEnemy(10);
        }
    }
}

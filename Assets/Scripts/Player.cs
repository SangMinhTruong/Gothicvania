using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public int fallBoundary = -10;
    public Animator mAnim;
    private AudioManager audioManager;
    //public static Player instance;
    //public string deathSoundName = "DeathVoice";
    //public string damageSoundName = "Grunt";

    // private AudioManager audioManager;

    [SerializeField]
    private Status statusIndicator;
    public Transform death;
    private PlayerStat stats;

    void Awake()
    {
        //if(instance==null)
        //{
        //    instance = this;
        //}
        audioManager = AudioManager.instance;
    }
    void Start()
    {
        stats = PlayerStat.instance;
        mAnim = GetComponent<Animator>();
        stats.curHealth = stats.maxHealth;

        if (statusIndicator == null)
        {
            Debug.LogError("No status indicator referenced on Player");
        }
        else
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }

        //GameMaster.gm.onToggleUpgradeMenu += OnUpgradeMenuToggle;

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("PANIC! No audiomanager in scene.");
        }

        InvokeRepeating("RegenHealth", 1f / stats.healthRegenRate, 1f / stats.healthRegenRate);
    }

    void RegenHealth()
    {
        stats.curHealth += 1;
        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }

    void Update()
    {
        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        if (transform.position.y <= fallBoundary)
            DamagePlayer(9999999);
    }

    //void OnUpgradeMenuToggle(bool active)
    //{
    //    GetComponent<Platformer2DUserControl>().enabled = !active;
    //    Weapon _weapon = GetComponentInChildren<Weapon>();
    //    if (_weapon != null)
    //        _weapon.enabled = !active;
    //}

    //void OnDestroy()
    //{
    //    GameMaster.gm.onToggleUpgradeMenu -= OnUpgradeMenuToggle;
    //}

    public void DamagePlayer(int damage)
    {
        stats.curHealth -= damage;
        mAnim.Play("Hurt");
        audioManager.PlaySound("Hurt");
        if (stats.curHealth <= 0)
        {
            //play death sound
           // audioManager.PlaySound("Grunt");
            stats.gameOver.SetActive(true);
            //kill player
            // GameMaster.KillPlayer(this);
            Instantiate(death, new Vector3(transform.position.x,transform.position.y,transform.position.z),this.transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            //play damage sound
            //  audioManager.PlaySound(damageSoundName);
        }
        //Debug.Log("NANIIIIII");
        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }
    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        
        if (_colInfo.gameObject.tag == "Water")
        {
            DamagePlayer(999999);
        }
    }
}

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

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

        public int damage = 40;

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public EnemyStats stats = new EnemyStats();
    private Animation myAnim;
    //public AnimationClip deathParticles;
    public Transform deathAnim;
    public float shakeAmt = 0.1f;
    public float shakeLength = 0.1f;

    //[Header("Optional: ")]
    [SerializeField]
    private Status statusIndicator;

    void Start()
    {
        myAnim = GetComponent<Animation>();
        stats.Init();
       // myAnim["deathParticles"].wrapMode = WrapMode.Once;
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
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
            DamageEnemy(10);
        }
    }
}

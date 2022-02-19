using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class Boss3Script : MonoBehaviour, IBoss
{
    #region private
    private float _health;
    private int _damage;
    private readonly int _phases = 2;
    private int _currentPhase;
    public int bossMaxHealth = 50;

    #endregion
    public static Boss3Script instance;

    public float Health { get => _health; set => _health = value; }

    public int Damage => _damage;

    public int Phases => _phases;
    public int CurrentPhase { get => _currentPhase; set => _currentPhase = value; }
    int IBoss.Phases { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int MaxHealth { get => bossMaxHealth; set => bossMaxHealth = value; }

    public bool isInvincible;

    public GameObject player;
    SaveObject so;

    public Animator animator;
    public string _currenState;
    public string SHOOT_STREIGHT = "boss3_shootStreight";
    public string IDLE_BOW = "boss3_idleBow";
    public string SHOOT_UP = "boss3_shootUp";
    public string SLASH = "boss3_slash";
    public string IDLE = "boss3_idle";
    public string CHANGE = "boss3_changeForm";
    public string CHANGE_BACK = "boss3_ChangeFormBack";
    public string RUN = "boss3_run";

    private PlayerActions pa;

    private bool isSlashed = false;
    private bool isRushing = false;
    float x;
    public float goal = -7.8f;
    float nextRushPeriod = 10f;
    float nextRush = 5f;
    Vector3 lastPos = new Vector3(6.71f,-2.67f,0);
    public void TakeDamage(float damage)
    {

        if (isInvincible)
        {
            //CurrentPhase = 1;
            Debug.Log("Boss is invincible, health: " + Health);
        }
        if (!isInvincible)
        {
            //CurrentPhase = 2;
            Health -= damage;
            pa.specialLoad++;
            print(pa.specialLoad);
        }
        if (Health <= 0)
        {
            Health = 0;
            CurrentPhase = 3;
            Time.timeScale = 0f;
            //so = SaveLoad.Load();
            if (!so.lvl3IsCompleted)
            {
                so.lvl3IsCompleted = true;
                so.skillPoints++;
            }
            SaveLoad.Save(so);
        }
        Debug.Log("Boss health: " + Health);
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = bossMaxHealth;
        CurrentPhase = 1;
        isInvincible = true;
        pa = player.GetComponent<PlayerActions>();
        so = SaveLoad.Load();
        animator = GetComponent<Animator>();
        ChangeAnimationState(IDLE);
        nextRush = Time.time+3;
        Physics2D.IgnoreLayerCollision(10, 11);
    }
    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            CurrentPhase = 1;
        }
        if (!isInvincible && Health > 0)
        {
            CurrentPhase = 2;
        }

        if (CurrentPhase == 1)
        {
            //actions for phase 1
            //checking if the boss is not in animation is needed.
            float distance = (player.transform.position - gameObject.transform.position).magnitude;//checking how far is the player from the boss
            if (distance <= 3f && !isSlashed && !isRushing) // if the player is far 3f or less - execute following code
            {
                //Debug.Log("Slash");
                //Slash animation
                //ChangeAnimationState()
                isSlashed = true;
                Slash();
            }
            else if (!isSlashed && !isRushing && Time.time > nextRush)
            {
                nextRush = Time.time + nextRushPeriod;
                //Rush();
                isRushing = true;
                ChangeAnimationState(RUN);
            }
            Rush2();

        }
        if (CurrentPhase == 2)
        {
            
            //actions for phase 2
            //random generator for deciding - straight arrow fire or 3 arrows fired at once
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerActions>().TakeHit();
        }
    }

    public void ChangeAnimationState(string newState)
    {
        if (_currenState == newState) return;
        animator.Play(newState);
        _currenState = newState;
    }
    private async void Slash()
    {
        ChangeAnimationState(SLASH);
        await Task.Delay(840);
        ChangeAnimationState(IDLE);
        isSlashed = false;
    }
    private async void Rush()
    {
        isRushing = true;
        ChangeAnimationState(RUN);
        do
        {
            if (CurrentPhase == 2) break;
            transform.position -= new Vector3(1,0,0) * .2f;
            await Task.Delay(50);
        } while (transform.position.x > goal);
        transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
        do
        {
            if (CurrentPhase == 2)break;
            transform.position += new Vector3(1, 0, 0) * .2f;
            await Task.Delay(50);
        } while (transform.position.x < 6.71);
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        isRushing = false;
        ChangeAnimationState(IDLE);
    }
    private void Rush2()
    {
        if (isRushing)
        {
            if (lastPos == new Vector3(6.71f, lastPos.y, lastPos.z))
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                transform.position -= new Vector3(1, 0, 0) * 5f*Time.deltaTime;
                if (transform.position.x <= -7.8f)
                {
                    lastPos = new Vector3(-7.8f, lastPos.y, lastPos.z);
                    
                }
            }
            if (lastPos == new Vector3(-7.8f, lastPos.y, lastPos.z))
            {
                transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                transform.position += new Vector3(1, 0, 0) * 5f * Time.deltaTime;
                if (transform.position.x >= 6.71f)
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    lastPos = new Vector3(6.71f, lastPos.y, lastPos.z);
                    isRushing = false;
                    ChangeAnimationState(IDLE);
                }
            }
        }
       
        //transform.position -=
    }
}
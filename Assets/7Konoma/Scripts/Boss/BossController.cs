using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    [Header("ƒ{ƒX‚ÌHP")]
    int _hp;
    
    [SerializeField]
    [Header("–³“GŽžŠÔ")]
    float _continueTime;

    BossState _nowState;

    SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _nowState = BossState.Nomal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == "Player2D")
        {
            if (_nowState == BossState.Nomal)
            {
                if (_hp > 0)
                {
                    _hp--;
                    _nowState = BossState.Damage;
                    OnDamage();
                }
                else
                {
                    _nowState = BossState.Hp0Rendition;
                    OnDamage();
                }
            }
        }
    }

    private void OnDamage()
    {
        switch (_nowState)
        {
            case BossState.Damage:
                    StartCoroutine("Damgeoff");               
                break;

            case BossState.Hp0Rendition:
                gameObject.SetActive(false);
                break;
        }
    }

    IEnumerator Damgeoff()
    {
        float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
        _sprite.color = new Color(1f, 1f, 1f, level);

        yield return new WaitForSeconds(_continueTime);
        
        _sprite.color = new Color(1f, 1f, 1f, 1f);
        _nowState = BossState.Nomal;
        Debug.Log(_nowState);
    }
}
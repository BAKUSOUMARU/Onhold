using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

enum State
{
    Nomal,
    Damage,
    hp0,
}

public class BossController : MonoBehaviour
{
    [SerializeField]
    [Header("É{ÉXÇÃHP")]
    int _hp;

    [SerializeField]
    float _jump;

    Rigidbody2D _rb2;

    State _nowState;

    SpriteRenderer _sprite;
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == ("Player2D"))
        {
            if (_hp > 0)
            {
                _hp--;
                _nowState = State.Damage;
                OnDamage();
                Debug.Log(_nowState);
            }
            else
            {
                _nowState = State.hp0;
                OnDamage();
                Debug.Log(_nowState);
            }
        }
    }

    private void OnDamage()
    {
        switch (_nowState)
        {
            case State.Damage:
                float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
                _sprite.color = new Color(1f, 1f, 1f, level);
                StartCoroutine("Damgeoff");
                break;

            case State.hp0:
                this.gameObject.SetActive(false);
                break;
        }
    }

    IEnumerator Damgeoff()
    {
        yield return new WaitForSeconds(0.7f);
        _sprite.color = new Color(1f, 1f, 1f, 1f);
        _nowState = State.Nomal;
        Debug.Log(_nowState);
    }
}
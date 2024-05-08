using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{   //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    public GameObject endScreen;

    public bool invencible = false;

    [Header("TextMeshPro")]
    public TextMeshPro uiTextPowerUp;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    //privates
    private bool _canRun;
    private Vector3 _pos;
    private Vector3 _startPosition;
    private float _currentSpeed;
    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }

    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) //defeat condition (collided with enemy)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if (!invencible) EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            if (!invencible) EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void startToRun()
    {
        _canRun = true;
    }

    #region POWER UPS
    public void SetPowerUpText(string s) //set up the power-up text
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f) //set new speed value
    {
        _currentSpeed = f;
    }
    public void ResetSpeed() //resets the speed value
    {
        _currentSpeed = speed;
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight(float animationDuration)
    {
        /*var p = transform.position;
        p.y = _startPosition.y;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y, animationDuration);
    }

    
    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}

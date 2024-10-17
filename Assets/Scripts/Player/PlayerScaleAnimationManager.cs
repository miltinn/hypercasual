using DG.Tweening;
using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleAnimationManager : Singleton<PlayerScaleAnimationManager>
{
    [Header("Scale Animation")]
    public float playerScaleDuration = 2f;
    public Ease playerScaleEase = Ease.Linear;
    public Vector3 initialPlayerScale = Vector3.zero;


    private float _endPlayerScale = 1f;

    public void LerpScale()
    {
        gameObject.transform.localScale = initialPlayerScale;
        gameObject.transform.DOScale(_endPlayerScale, playerScaleDuration).SetEase(playerScaleEase);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) LerpScale();
    }

    private void Start()
    {
        PlayerController.Instance.LerpScale();
    }
}

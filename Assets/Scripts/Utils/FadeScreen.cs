using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Utils;

public class FadeScreen : Singleton<FadeScreen>
{
    [SerializeField] private float fadeDuration;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void FadeIn() { image.DOFade(0, fadeDuration); }
    public void FadeOut() { image.DOFade(1, fadeDuration); }

    public float GetFadeDuration() { return fadeDuration; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    void HideOnLastFrame() { gameObject.SetActive(false); }
}
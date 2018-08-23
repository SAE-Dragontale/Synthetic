using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animation;


    public void Walk()
    {
        _animation.SetBool("walking", true);
    }

    public void Idle()
    {
        _animation.SetBool("walking", false);
    }
}

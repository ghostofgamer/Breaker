using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : EndScreen
{
    [SerializeField] private Animator _animator;
    
    private void ScreenMover()
    {
        _animator.Play("ScreenOpen");
    }
}

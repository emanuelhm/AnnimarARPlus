using UnityEngine;
using UnityEngine.Events;

public class AnimationBehavior : MonoBehaviour
{
    public Animator Animator;

    private bool state;

    public bool isStopped;

    public string Parameter;

    public bool DefaultState;

    public UnityEvent OnToggled;

    public UnityEvent OnSpeedToggled;

    private void Start()
    {
        state = DefaultState;
        Animator.SetBool(Parameter, DefaultState);
    }

    public void ToggleAnimation()
    {
        state = !state;
        Animator.SetBool(Parameter, state);
        OnToggled.Invoke();
    }

    public void PlayFromStart()
    {
        Animator.Play("Default", -1, 0f);
    }

    private void OnDisable()
    {
        Animator.enabled = false;
    }

    public void ToggleSpeed() 
    {
        Animator.enabled = true;

        if (isStopped)
        {
            Animator.speed = 1;
        }
        else
        {
            Animator.speed = 0;
        }

        isStopped = !isStopped;
        OnSpeedToggled.Invoke();
    }
}
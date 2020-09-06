using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float Time;

    public UnityEvent Function;

    private bool ispressed = false;

    private bool isRunning;

    private void Update()
    {
        if (ispressed)
        {
            if (!isRunning)
            {
                StartCoroutine(RunFunction());
            }
        }
    }

    public IEnumerator RunFunction()
    {
        isRunning = true;

        yield return new WaitForSeconds(Time);
        Function.Invoke();

        isRunning = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}
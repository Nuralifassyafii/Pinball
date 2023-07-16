using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public enum SwitchState
    {
        on,
        off,
        blink
    }

    public Collider bola;
    public Material offmaterial;
    public Material onmaterial;

    private bool isOn;
    private SwitchState switchstate;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        isOn = false;

        renderer.material = offmaterial;

        Set(false)  ;

        StartCoroutine(BlinkTimer(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle();
        }
    }

    public void Set(bool state)
    {
        isOn = state;
        if (isOn == true)
        {
            switchstate = SwitchState.on;
            renderer.material = onmaterial;
            StopAllCoroutines();
        }

        else
        {
            switchstate = SwitchState.off;
            renderer.material = offmaterial;
            StartCoroutine(BlinkTimer(5));
        }
    }

    public void Toggle()
    {
        if(switchstate == SwitchState.on)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }

    private IEnumerator Blink(int times)
    {
        switchstate = SwitchState.blink;

        for(int i = 0; i < times; i++)
        {
            renderer.material = onmaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offmaterial;
            yield return new WaitForSeconds(0.5f);
        }

        switchstate = SwitchState.off;

        StartCoroutine(BlinkTimer(5));
    }

    private IEnumerator BlinkTimer(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}

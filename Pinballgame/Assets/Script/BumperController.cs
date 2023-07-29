using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorChange { One, Two, Three }

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public Color color2;
    public Color color3;
    public ColorChange colorchange;
    

    private Renderer renderer;
    private Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();

        renderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fungsi ganti warna
    public void ChangeColor()
    {
        if(colorchange == ColorChange.One)
        {
            renderer.material.color = color2;
            colorchange = ColorChange.Two;
        }else if (colorchange == ColorChange.Two)
        {
            renderer.material.color = color3;
            colorchange = ColorChange.Three;
        }
        else
        {
            renderer.material.color = color;
            colorchange = ColorChange.One;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            ChangeColor();
            Rigidbody bolarig = bola.GetComponent<Rigidbody>();
            bolarig.velocity *= multiplier;

            animator.SetTrigger("Hit");
            
        }
    }
}

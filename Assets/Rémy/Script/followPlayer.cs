using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class followPlayer : MonoBehaviour
{
    GameObject player;
    public int inc;

    //Sound
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    bool songPlayed;
    //animation
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        inc = 0;
        animator = GetComponent<Animator>();
        songPlayed= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null && inc != -2)
        {
            inc = -2;
            
        }
        else if (inc == -2)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * 20);
            if (!songPlayed)
            {
                songPlayed = true;
                audioSource.PlayOneShot(clip);
            }
            if (this.transform.position.y > 10) Destroy(this.gameObject);

        }
        else
        {
            Vector3 dir = player.transform.position - transform.position;
            if (dir.magnitude >1)
            {
                transform.Translate(dir.normalized * 10 * Time.deltaTime);

                if (Vector3.Angle(dir, Vector3.up)<90)
                {
                    if (Vector3.Angle(dir, Vector3.right) < 45)
                    {
                        animator.SetInteger("AnimePar", 7);
                    }
                    else if (Vector3.Angle(dir, Vector3.left) < 45)
                    {
                        animator.SetInteger("AnimePar", 5);
                    }
                    else
                    {
                        animator.SetInteger("AnimePar", 3);
                    }
                    
                }
                else if (Vector3.Angle(dir, Vector3.down) < 90)
                {
                    if (Vector3.Angle(dir, Vector3.right) < 45)
                    {
                        animator.SetInteger("AnimePar", 7);
                    }
                    else if (Vector3.Angle(dir, Vector3.left) < 45)
                    {
                        animator.SetInteger("AnimePar", 5);
                    }
                    else
                    {
                        animator.SetInteger("AnimePar", 1);
                    }
                }
            }
            else
            {
                int getPar = animator.GetInteger("AnimePar");
                if (getPar == 1)
                {
                    animator.SetInteger("AnimePar", 2);
                }
                else if (getPar == 3)
                {
                    animator.SetInteger("AnimePar", 4);
                }
                else if (getPar == 5)
                {
                    animator.SetInteger("AnimePar", 6);
                }
                else if (getPar == 7)
                {
                    animator.SetInteger("AnimePar", 8);
                }
            }
        }

    }

}

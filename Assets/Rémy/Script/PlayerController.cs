using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    //Control
    [SerializeField] bool clavier;
    bool control;

    //Parameters
    [SerializeField] GameObject player;
    float horVal,verVal;
    float speed = 5;
    public int inc;
    public int vie;
    bool once;

    //Animation
    Animator animator;

    //UI
    [SerializeField] GameObject MenuGameOver;

    // Start is called before the first frame update
    void Start()
    {
        control = true;
        inc = 0;
        player = this.gameObject;
        animator = GetComponent<Animator>();
        vie = 1;
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Controle

            if (clavier)
            {
                Vector2 pos = transform.position;

                if (control && ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))))
                {
                    if (Input.GetKey(KeyCode.RightArrow) && pos.x < 8.25f)
                    {
                        player.transform.Translate(Vector2.right * speed * Time.deltaTime);
                        animator.SetInteger("AnimePar", 7);
                    }
                    if (Input.GetKey(KeyCode.LeftArrow) && pos.x > -8.25f)
                    {
                        player.transform.Translate(Vector2.left * speed * Time.deltaTime);
                        animator.SetInteger("AnimePar", 5);
                    }

                    if (Input.GetKey(KeyCode.UpArrow) && pos.y < 4.25f)
                    {
                        player.transform.Translate(Vector2.up * speed * Time.deltaTime);
                        animator.SetInteger("AnimePar", 1);
                    }
                    if (Input.GetKey(KeyCode.DownArrow) && pos.y > -4.25f)
                    {
                        player.transform.Translate(Vector2.down * speed * Time.deltaTime);
                        animator.SetInteger("AnimePar", 3);
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
            else
            {
                Vector2 pos = transform.position;

            if (control)
            {
                horVal = Input.GetAxis("Horizontal");
                verVal = Input.GetAxis("Vertical");
            }
            else
            {
                horVal = 0;
                verVal = 0;
            } 

                if (verVal + horVal != 0)
                {
                    if (Input.anyKeyDown || Input.anyKey)
                    {
                        horVal = 0;
                        clavier = true;
                    }

                    if (Mathf.Abs(horVal) > 0.2)
                    {
                        if (horVal > 0.2 && pos.x < 8.25f)
                        {
                            player.transform.Translate(Vector2.right * speed * Time.deltaTime);
                            animator.SetInteger("AnimePar", 7);
                        }
                        if (horVal < 0.2 && pos.x > -8.25f)
                        {
                            player.transform.Translate(Vector2.left * speed * Time.deltaTime);
                            animator.SetInteger("AnimePar", 5);
                        }
                    }



                    if (Input.anyKeyDown || Input.anyKey)
                    {
                        horVal = 0;
                        clavier = true;
                    }

                    if (Mathf.Abs(verVal) > 0.2)
                    {
                        if (verVal > 0 && pos.y < 4.25f)
                        {
                            player.transform.Translate(Vector2.up * speed * Time.deltaTime);
                            animator.SetInteger("AnimePar", 1);
                        }
                        if (verVal < 0 && pos.y > -4.25f)
                        {
                            player.transform.Translate(Vector2.down * speed * Time.deltaTime);
                            animator.SetInteger("AnimePar", 3);
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

        //vie
        if (vie <= 0 && !once)
        {
                once = true;
                animator.SetInteger("AnimePar", 9);
                control = false;
                MenuGameOver.GetComponent<MenuGameOver>().GameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ptero" || collision.tag == "Ptero" || collision.tag == "Tripy")
        {
            vie--;
            if(vie==1)
            {
                GameObject.FindGameObjectWithTag("Finish").GetComponent<followPlayer>().inc = -2;
            }
        }
    }



}

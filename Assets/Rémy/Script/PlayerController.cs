using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Control
    [SerializeField] bool clavier;
    bool control;
    bool trebucheB;
    Vector3 dir, calculDir;
    float decompteDir;

    //Parameters
    [SerializeField] GameObject player;
    float horVal,verVal;
    float speed = 5;
    public int inc;
    public int vie;

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
        decompteDir= 0;
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

        if (trebucheB)
        {
            transform.Translate(dir*10*Time.deltaTime);
        }

        //vie
        if (vie <= 0)
        {
            animator.SetInteger("AnimePar", 9);
            control = false;
            MenuGameOver.GetComponent<MenuGameOver>().GameOver= true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Timer>().decompteOn = false;

        }

        //dir

        dir = (transform.position - calculDir);
        if (dir.magnitude > 0.01f)
        {
            dir = dir.normalized/2;
        }
        else
        {
            dir = Vector3.up/2;
        }

        decompteDir -= Time.deltaTime;
        if(decompteDir< 0)
        {
            calculDir = transform.position;
            decompteDir = 0.1f;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ptero" || collision.tag == "Ptero" || collision.tag == "Tripy")
        {
            vie--;
            if (vie == 1)
            {
                GameObject.FindGameObjectWithTag("Finish").GetComponent<followPlayer>().inc = -2;
            }
        }
        else if (collision.tag == "Arbre" || collision.tag == "Rocher")
        {
            trebuche();
        }
    }

    void trebuche()
    {
        control = false;
        trebucheB = true;

        StartCoroutine("trebucheStop");
    }
    IEnumerator trebucheStop()
    {
        yield return new WaitForSeconds(0.4f);
        trebucheB = false;
        StartCoroutine("trebucheStop2");
    }
    IEnumerator trebucheStop2()
    {
        yield return new WaitForSeconds(0.1f);
        control = true;
        transform.SetLocalPositionAndRotation(this.transform.position, Quaternion.identity);
    }



}

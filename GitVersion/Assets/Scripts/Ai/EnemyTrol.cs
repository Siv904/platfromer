 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class EnemyTrol : MonoBehaviour
 {
    Animator anim;

    public GameObject player;

    public bool flip;

    public float speed;

    public int MaxDist = 40;
    public int MinDist = 1;

     void Start()
     {
        anim = GetComponent<Animator> ();
     }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= MaxDist)
        {
            Vector3 scale = transform.localScale;
            if(player.transform.position.x > transform.position.x)
            {
                scale.z = Mathf.Abs(scale.z) * -1 * (flip ? -1 : 1);
                transform.Translate(0, 0 , speed * Time.deltaTime * -1);
            } else {
                scale.z = Mathf.Abs(scale.z) * (flip ? -1 : 1);
                transform.Translate(0, 0 , speed * Time.deltaTime);
            }

            transform.localScale = scale;

            //Check 
            if (Vector3.Distance(transform.position, player.transform.position) <= MinDist + 1)
             {
                 anim.SetBool("Attacking", true);
             }
             else
             {
                anim.SetBool("Attacking", false);
             }
        }
    }
}

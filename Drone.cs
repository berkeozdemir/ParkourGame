using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;

    public Vector3 offset;

    public float speed = 3f;

    public float follow_distance = 10f;

    private float cooldown = 3f;

    public GameObject mesh;

    public GameObject bullet;

    public float health = 25f;

    public GameObject death_effect;

    public AudioClip death_sound;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();

    }

    private void FollowPlayer()
    {
        //Look to Player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(offset);
        //Move to Player
        if (Vector3.Distance(transform.position, player.position) >= follow_distance)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed * -1);
        }
        else
        {
            transform.RotateAround(player.position, transform.forward, Time.deltaTime * speed * Random.Range(0.2f, 3f));
        }
    }

    private void Shot()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 2f;
            //Shot
            mesh.GetComponent<Animator>().SetTrigger("shot");
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(-90,0,0)));
        }
    }

    private void Death()
    {
        if(health <= 0)
        {
            //Spawn Particle
            Instantiate(death_effect, transform.position, Quaternion.identity);
            // Play Sound Effect
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(death_sound , 0.2f);
            //Destroy Gameobject

             
            Destroy(this.gameObject);
        }
    }
}

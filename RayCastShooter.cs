using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShooter : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate = .25f;

    public float weaponRange = 50f;
    public float hitForce = 100f;

    public Transform gunEnd;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)

        {

            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(transform.position, transform.forward, out hit, weaponRange))
            {
                Debug.DrawRay(transform.position, transform.forward * weaponRange, Color.green);
                laserLine.SetPosition(1, hit.point);
                Debug.Log("Did Hit");

                DamageControl health = hit.collider.GetComponent<DamageControl>();
                //GameSceneManager tmScore = GetComponent<GameSceneManager>();
                if (health != null)
                {

                    health.Damage(gunDamage);

                    PlayerPrefs.SetInt("Score", 1);
                }
               

                /*if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }*/
            }
            else
            {
                laserLine.SetPosition(1, transform.position + (transform.forward * weaponRange));
                Debug.Log("Did Not Hit");
            }
        }

    }

    private IEnumerator ShotEffect()

    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}

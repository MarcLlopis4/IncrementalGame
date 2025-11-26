using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] private Material mat;
    [SerializeField] private float hitTime;

    [Header("Stats")]
    [SerializeField] private float life;
    [SerializeField] private float maxLife;
    [SerializeField] private float damage;

    private NavMeshAgent agent;
    private GameObject player;
    [SerializeField] private TextMeshProUGUI damageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is createdç


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(player.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isStopped)
        {
            //Attack
        }
        else
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Bullet":

                hitMaterialCoroutine();
                damageTextCoroutine(5);
                TakeDamage(5);

                break;

        }
    }


    private void TakeDamage(float damage)
    {
        if(life-damage <= 0)
        {
            life -= damage;
            Death();
        }
        else
        {
            life -= damage;
        }
    }

    private void Death()
    {
        //Death
        Destroy(gameObject);
    }

    private void hitMaterialCoroutine()
    {
        StartCoroutine(hit_material());
    }

    private void damageTextCoroutine(float damage)
    {
        StartCoroutine(DamageText(damage));
    }

    IEnumerator DamageText(float damage)
    {
        damageText.text = damage.ToString();

        damageText.gameObject.SetActive(true);

        //MovementOfUI

        yield return new WaitForSeconds(2);

        damageText.gameObject.SetActive(false);

        yield return null;
    }


    IEnumerator hit_material()
    {
        float time = 0;

        while (time < hitTime)
        {
            float emission = Mathf.Lerp(0f, 0.5f, time / hitTime);

            time += Time.deltaTime;
            Debug.Log(time);
            mat.SetFloat("_Emission", emission);
            yield return null;
        }

        time = 0;

        while (time < hitTime)
        {
            float emission = Mathf.Lerp(0.5f, 0f, time / hitTime);
            time += Time.deltaTime;
            Debug.Log(time);
            mat.SetFloat("_Emission", emission);
            yield return null;
        }
    }
}

using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
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

    [SerializeField] private AnimationCurve curve;
    private RectTransform canvasRect;
    [SerializeField] private float durationDamageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is createdç


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        agent = GetComponent<NavMeshAgent>();

        canvasRect = damageText.gameObject.transform.parent.GetComponent<RectTransform>();





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
            agent.SetDestination(player.transform.position);
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

        damageText.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(canvasRect.sizeDelta.x/2, 0);

        damageText.gameObject.SetActive(true);

        //MovementOfUI
        float timeC = 0;

        RectTransform initPos = damageText.transform.GetComponent<RectTransform>();
        Vector2 posInitial = initPos.anchoredPosition;
        float goToPosX = Random.Range(0, canvasRect.sizeDelta.x);
        float goToPosY = Random.Range(0, canvasRect.sizeDelta.y/4);

        damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, 1);

        while (timeC < durationDamageText)
        {
            float posX = Mathf.Lerp(posInitial.x, goToPosX, timeC / durationDamageText);
            float posY = Mathf.Lerp(posInitial.y, goToPosY, timeC / durationDamageText);

            initPos.anchoredPosition = new Vector2(posX, posY);

            timeC += Time.deltaTime;

            yield return null;
        }

        timeC = 0;
        
        float alpha = damageText.color.a;
        while (timeC < durationDamageText)
        {
            damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, Mathf.Lerp(alpha, 0, timeC / durationDamageText));
            timeC += Time.deltaTime;
            yield return null;
               
        }
        
       
        
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

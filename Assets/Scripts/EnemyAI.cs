using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Transform player;
    public bool hasDestination;
    public float hp = 1;
    [SerializeField] private List<AudioClip> zombieClips = new List<AudioClip>();
    [SerializeField] private AudioSource zombieAudio;
    [SerializeField] private Image healthBar;
    [SerializeField] private Material material;
    [SerializeField] private List<Renderer> renderers;
    private TextMeshProUGUI keysCount;
    private NoticeController noticeController;
    private AudioSource deathAudio;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        noticeController = GameObject.FindGameObjectWithTag("NoticeController").GetComponent<NoticeController>();
        StartCoroutine(AudioCoroutine());
        deathAudio = GameObject.FindGameObjectWithTag("ZombieDeathAudio").GetComponent<AudioSource>();
        keysCount = GameObject.FindGameObjectWithTag("KeysCount").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (hasDestination)
        {
            agent.SetDestination(player.position);
        }

        if (hp <= 0)
        {
            deathAudio.Play();
            noticeController.Notify(1, "+1 ключ");
            Elevator.keysCount++;
            keysCount.text = $"{Elevator.keysCount}";
            ParticleSystem deathParticles = GameObject.FindGameObjectWithTag("DeathParticles").GetComponent<ParticleSystem>();
            deathParticles.transform.position = transform.position;
            deathParticles.Emit(20);
            Destroy(gameObject);
        }
    }

    public void SetHp(float health)
    {
        if (health < hp && health > 0)
        {
            StartCoroutine(DamageCoroutine());
        }
        hp = health;
        //healthBar.fillAmount = hp;
    }

    private IEnumerator AudioCoroutine()
    {
        while (true)
        {
            if (hasDestination)
            {
                AudioClip clip = zombieClips[Random.Range(0, zombieClips.Count)];
                zombieAudio.clip = clip;
                zombieAudio.Play();
            }
            yield return new WaitForSeconds(4f);
        }
    }

    private IEnumerator DamageCoroutine()
    {
        foreach (Renderer renderer in renderers)
            renderer.material.color = new Color(1f, .4f, .4f);

        yield return new WaitForSeconds(.2f);

        foreach (Renderer renderer in renderers)
            renderer.material.color = Color.white;
    }
}

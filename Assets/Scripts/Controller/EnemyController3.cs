using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController3 : MonoBehaviour
{
    Animator enemyAnim;
    CharacterController characterController;

    public Transform target;

    NavMeshAgent agent;

    public float distance;

    public float health = 100;

    Transform spawnPointTransform; // D��man�n yeniden do�aca�� spawn noktas�

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        enemyAnim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        spawnPointTransform = transform; // �rne�in, d��man�n ba�lang�� pozisyonunu spawn noktas� olarak ayarlayabilirsiniz.
    }

    void Update()
    {


        enemyAnim.SetFloat("can", health);

        if (health <= 0)
        {

            Destroy(this.gameObject);
            StartCoroutine(RespawnAfterDelay(3f)); // 3 saniye sonra respawn etmek i�in
            return; // D��man�n geri kalan�n� kontrol etmeyi durdur

          
        }

        enemyAnim.SetFloat("Speed", agent.velocity.magnitude);

        agent.enabled = true;
        agent.speed = 5f;
        agent.destination = target.position;

        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Transform spawnPoint = GetSpawnPoint(); // Do�um noktas�n� al
        transform.position = spawnPoint.position; // D��man� do�um noktas�na ta��
        health = 100; // Sa�l��� yeniden ayarla veya ba�ka inisyalizasyonlar yap

        // E�er spawnPoint belirli bir yere g�re hareket ediyorsa:
        // agent.Warp(spawnPoint.position);
    }

    Transform GetSpawnPoint()
    {
        // D��man�n yeniden do�aca�� noktay� belirleyen bir fonksiyon.
        // �rne�in, sabit bir spawn noktas� kullanabilirsiniz.
        return spawnPointTransform;
    }
}

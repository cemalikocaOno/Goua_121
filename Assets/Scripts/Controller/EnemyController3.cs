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

    Transform spawnPointTransform; // Düþmanýn yeniden doðacaðý spawn noktasý

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        enemyAnim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        spawnPointTransform = transform; // Örneðin, düþmanýn baþlangýç pozisyonunu spawn noktasý olarak ayarlayabilirsiniz.
    }

    void Update()
    {


        enemyAnim.SetFloat("can", health);

        if (health <= 0)
        {

            Destroy(this.gameObject);
            StartCoroutine(RespawnAfterDelay(3f)); // 3 saniye sonra respawn etmek için
            return; // Düþmanýn geri kalanýný kontrol etmeyi durdur

          
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

        Transform spawnPoint = GetSpawnPoint(); // Doðum noktasýný al
        transform.position = spawnPoint.position; // Düþmaný doðum noktasýna taþý
        health = 100; // Saðlýðý yeniden ayarla veya baþka inisyalizasyonlar yap

        // Eðer spawnPoint belirli bir yere göre hareket ediyorsa:
        // agent.Warp(spawnPoint.position);
    }

    Transform GetSpawnPoint()
    {
        // Düþmanýn yeniden doðacaðý noktayý belirleyen bir fonksiyon.
        // Örneðin, sabit bir spawn noktasý kullanabilirsiniz.
        return spawnPointTransform;
    }
}

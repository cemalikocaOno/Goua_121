using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// Apply forward force to instantiated prefab
    /// </summary>
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The projectile that's created")]
        GameObject m_ProjectilePrefab = null;

        [SerializeField]
        [Tooltip("The point that the project is created")]
        Transform m_StartPoint = null;

        [SerializeField]
        [Tooltip("The speed at which the projectile is launched")]
        float m_LaunchSpeed = 1.0f;


        //public List<EnemyController> _enemyControllers = new List<EnemyController>();

        public EnemyController _enemyController;
        public EnemyController2 _enemyController2;
        public EnemyController3 _enemyController3;

        public void Fire()
        {
            GameObject newObject = Instantiate(m_ProjectilePrefab, m_StartPoint.position, m_StartPoint.rotation, null);

            if (newObject.TryGetComponent(out Rigidbody rigidBody))
                ApplyForce(rigidBody);
        }

        void ApplyForce(Rigidbody rigidBody)
        {
            Vector3 force = m_StartPoint.forward * m_LaunchSpeed;
            rigidBody.AddForce(force);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemyController.health -= 50;
                
                // Destroy(gameObject); // Destroy the projectile on impact
            }
            if (other.CompareTag("Enemy2"))
            {

                _enemyController2.health -= 50;
                
                // Destroy(gameObject); // Destroy the projectile on impact
            }
            if (other.CompareTag("Enemy3"))
            {

                _enemyController3.health -= 50;

                // Destroy(gameObject); // Destroy the projectile on impact
            }
        }
    }
}

using UnityEngine;

namespace EnemyScripts
{
    public class EnemyBehaviourHandler : MonoBehaviour
    {
        [SerializeField] private Transform spawnPlatform;

        public void Respawn()
        {
            transform.position = new Vector3(spawnPlatform.position.x, spawnPlatform.position.y + 1.0f, 0.0f);
            GetComponent<Collider2D>().isTrigger = false;
            gameObject.SetActive(true);
        }
    }
}
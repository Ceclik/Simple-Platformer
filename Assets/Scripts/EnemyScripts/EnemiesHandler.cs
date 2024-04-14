using System;
using MenuHandlers.LoseMenu;
using UnityEngine;

namespace EnemyScripts
{
    public class EnemiesHandler : MonoBehaviour
    {
        private EnemyBehaviourHandler[] _enemies;

        private MenuButtonsHandler _buttonsHandler;

        private void Start()
        {
            _enemies = new EnemyBehaviourHandler[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
                _enemies[i] = transform.GetChild(i).GetComponent<EnemyBehaviourHandler>();

            _buttonsHandler = GameObject.Find("ButtonsHandler").GetComponent<MenuButtonsHandler>();
            _buttonsHandler.OnRestartLevel += RespawnAllEnemies;
        }

        private void OnDestroy()
        {
            _buttonsHandler.OnRestartLevel -= RespawnAllEnemies;
        }

        private void RespawnAllEnemies()
        {
            foreach (var enemy in _enemies)
                enemy.Respawn();
        }
    }
}
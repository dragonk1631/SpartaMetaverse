using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class EnemyManager : MonoBehaviour
    {
        private Coroutine waveRoutine;

        [SerializeField] private List<GameObject> enemyPrefabs;

        [SerializeField] List<Rect> spawnAreas;
        [SerializeField] private Color gizmoColor = new Color(1, 0, 0, 3f);
        private List<EnemyController> activeEnemies = new List<EnemyController>();

        private bool enemySpawComplite;

        [SerializeField] private float timeBetweenSpawns = 0.2f;
        [SerializeField] private float timeBetweenWaves = 1f;

        public GameManager GM;

        public void Init(GameManager gm)
        {
            this.GM = gm;
        }

        public void StartWave(int waveCount)
        {
            if (waveCount <= 0)
            {
                GM.EndOfWave();
                return;
            }
            if (waveRoutine != null)
                StopCoroutine(waveRoutine);
            waveRoutine = StartCoroutine(SpawnWave(waveCount));
        }

        public void StopWave()
        {
            StopAllCoroutines();
        }

        private IEnumerator SpawnWave(int waveCount)
        {
            enemySpawComplite = false;
            yield return new WaitForSeconds(timeBetweenWaves);

            for (int i = 0; i < waveCount; i++)
            {
                yield return new WaitForSeconds(timeBetweenSpawns);
                SpawnRandomEnemy();
            }

            enemySpawComplite = true;
        }

        private void SpawnRandomEnemy()
        {
            if (enemyPrefabs.Count == 0 || spawnAreas.Count == 0)
            {
                Debug.LogWarning("에너미 프리팹 또는 스폰에어리어가 설정되지 않았습니다.");
                return;
            }

            GameObject randomPrefab = enemyPrefabs[Random.Range(0, spawnAreas.Count)];

            Rect RandomArea = spawnAreas[Random.Range(0, spawnAreas.Count)];

            Vector2 randomPosition = new Vector2(
                Random.Range(RandomArea.xMin, RandomArea.xMax),
                Random.Range(RandomArea.yMin, RandomArea.yMax)
                );

            GameObject spawnEnemy = Instantiate(
                randomPrefab, new Vector3(randomPosition.x, randomPosition.y), Quaternion.identity);
            EnemyController enemyController = spawnEnemy.GetComponent<EnemyController>();
            enemyController.Init(this, GM.player.transform);


            activeEnemies.Add(enemyController);
        }

        private void OnDrawGizmosSelected()
        {
            if (spawnAreas == null) return;

            Gizmos.color = gizmoColor;
            foreach (var area in spawnAreas)
            {
                Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
                Vector3 size = new Vector3(area.width, area.height);

                Gizmos.DrawCube(center, size);
            }
        }

        public void RemoveEnemyOnDeath(EnemyController enemy)
        {
            activeEnemies.Remove(enemy);
            if (enemySpawComplite && activeEnemies.Count == 0)
                GM.EndOfWave();
        }
    }
}

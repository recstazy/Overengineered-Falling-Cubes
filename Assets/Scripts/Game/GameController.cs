using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDamage
{
    public class GameController : MonoBehaviour, IDependent<IGameConfiguration>
    {
        private IGameConfiguration configuration;
        private List<IGameEndConditionWatcher> gameEndConditions;
        private List<GameObject> walls;

        private bool isGameEnded;

        private void OnDestroy()
        {
            EndGameLoop();
        }

        public void Initialize(IGameConfiguration configuration)
        {
            this.configuration = configuration;
            StartCoroutine(GameLoopRoutine());
        }

        private IEnumerator GameLoopRoutine()
        {
            while (true)
            {
                StartGameLoop();
                yield return new WaitUntil(() => isGameEnded);
                EndGameLoop();

                yield return null;
            }
        }

        private void StartGameLoop()
        {
            isGameEnded = false;
            var units = CreateUnits();
            CreatePlatforms();
            CreateEndConditions(units);
        }

        private void EndGameLoop()
        {
            if (gameEndConditions != null)
            {
                foreach (var c in gameEndConditions)
                    c?.Dispose();
            }

            ClearWalls();
        }

        private IEnumerable<Unit> CreateUnits()
        {
            var unitsCount = configuration.InitialUnitsCount;
            var units = new List<Unit>();

            for (int i = 0; i < unitsCount; i++)
            {
                var unit = configuration.UnitFactory.Create();
                units.Add(unit);
            }

            return units;
        }

        private void CreatePlatforms()
        {
            walls = new List<GameObject>();
            int wallsCount = configuration.InitialWallsCount;

            for (int i = 0; i < wallsCount; i++)
            {
                var wall = configuration.WallFactory.Create();
                walls.Add(wall.gameObject);
            }
        }

        private void ClearWalls()
        {
            foreach (var w in walls)
            {
                Destroy(w);
            }

            walls = null;
        }

        private void CreateEndConditions(IEnumerable<Unit> units)
        {
            gameEndConditions = new List<IGameEndConditionWatcher>();
            var allunitsDeadCondition = new AllUnitsDeadGameEndConditionWatcher(units);
            allunitsDeadCondition.OnGameEnded += GameEnded;
            gameEndConditions.Add(allunitsDeadCondition);
        }

        private void GameEnded() => isGameEnded = true;
    }
}

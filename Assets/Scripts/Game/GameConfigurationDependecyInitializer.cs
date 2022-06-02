using UnityEngine;

namespace FallingCubes
{
    public class GameConfigurationDependecyInitializer : MonoBehaviour
    {
        [SerializeField]
        private Object gameConfig;

        private void Awake()
        {
            var dependencies = GetComponentsInChildren<IDependent<IGameConfiguration>>();
            var config = gameConfig as IGameConfiguration;

            foreach (var d in dependencies)
            {
                d.Initialize(config);
            }
        }
    }
}

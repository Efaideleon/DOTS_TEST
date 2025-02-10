using UnityEngine;
using Unity.Entities;

public class ConfigAuthoring : MonoBehaviour
{
    [Header("Settings")]
    public int Id;

    [Header("Prefabs")]
    public GameObject CubePrefab;

    class Baker : Baker<ConfigAuthoring>  
    {
        public override void Bake(ConfigAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.None); 
            AddComponent(entity, new Config
            {
                Id = authoring.Id,
                cubePrefab = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic),
            });

        }
    }

    public struct Config : IComponentData
    {
        public int Id;
        public Entity cubePrefab;
    }
}

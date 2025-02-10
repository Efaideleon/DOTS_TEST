using UnityEngine;
using Unity.Entities;
using Unity.Collections;

public class ConfigAuthoring : MonoBehaviour
{
    [Header("Settings")]
    public string Name;
    public int Id;
    public string Color;

    [Header("Prefabs")]
    public GameObject CubePrefab;

    class Baker : Baker<ConfigAuthoring>  
    {
        public override void Bake(ConfigAuthoring authoring)
        {
            var entity = GetEntity(authoring, TransformUsageFlags.None); 
            AddComponent(entity, new Config
            {
                Name = authoring.Name,
                Id = authoring.Id,
                Color = authoring.Color,
                cubePrefab = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic),
            });
        }
    }

    public struct Config : IComponentData
    {
        public FixedString64Bytes Name;
        public int Id;
        public FixedString64Bytes Color;
        public Entity cubePrefab;
    }
}

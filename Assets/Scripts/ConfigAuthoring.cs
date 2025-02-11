using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Mathematics;

public class ConfigAuthoring : MonoBehaviour
{
    [Header("Settings")]
    public string Name;
    public int Id;
    public Color MyColor;

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
                MyColor = (Vector4)authoring.MyColor,
                CubePrefab = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic),
            });
        }
    }

}

public struct Config : IComponentData
{
    public FixedString64Bytes Name;
    public int Id;
    public float4 MyColor;
    public Entity CubePrefab;
}

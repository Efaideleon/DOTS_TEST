using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Rendering;

public partial struct SpawnSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Config>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        var config = SystemAPI.GetSingleton<Config>();

        // Instantiate cube
        var cubeTransform = state.EntityManager.GetComponentData<LocalTransform>(config.CubePrefab);
        Entity CubeEntity = state.EntityManager.Instantiate(config.CubePrefab);
        state.EntityManager.SetComponentData(CubeEntity, cubeTransform);
        /*state.EntityManager.AddComponentData(CubeEntity, new URPMaterialPropertyBaseColor*/
        /*{*/
        /*    Value = config.MyColor*/
        /*});*/
    }
}

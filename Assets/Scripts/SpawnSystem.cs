using Unity.Entities;
using Unity.Burst;

public partial struct SpawnSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate(Config);
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled = false;
        var config = SystemAPI.GetSingleton<Config>();
    }
}

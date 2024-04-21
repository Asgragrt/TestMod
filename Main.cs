using MelonLoader;
using Test.Managers;
using Test.Properties;

namespace Test;

public class Main : MelonMod
{
    public override void OnApplicationQuit()
    {
        ModManager.Terminate();
        base.OnApplicationQuit();
    }

    public override void OnInitializeMelon()
    {
        ModManager.Init();
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
}
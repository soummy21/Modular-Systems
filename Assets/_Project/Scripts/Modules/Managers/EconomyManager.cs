using UnityEngine;
using SoummySDK.DesignPatterns;

public class EconomyManager : Singleton<EconomyManager>
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}

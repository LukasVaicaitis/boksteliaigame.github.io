using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void BuyTurret1()
    {
        Debug.Log("Pirmas bokstas nupirktas!");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void BuyTurret2()
    {
        Debug.Log("Antras bokstas nupirktas!");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
    }
}

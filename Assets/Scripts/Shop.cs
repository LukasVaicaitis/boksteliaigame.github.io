using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint supportTurret;
    public TurretBlueprint missileTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret1()
    {
        Debug.Log("Pirmas bokstas pasirinktas!");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectTurret2()
    {
        Debug.Log("Antras bokstas pasirinktas!");
        buildManager.SelectTurretToBuild(supportTurret);
    }
    public void SelectTurret3()
    {
        Debug.Log("Trecias bokstas pasirinktas!");
        buildManager.SelectTurretToBuild(missileTurret);
    }
}

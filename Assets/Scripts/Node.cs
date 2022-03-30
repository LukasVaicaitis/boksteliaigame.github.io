using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private Color startColor;
    private Renderer rend;
    private GameObject turret;
    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        rend.material.color = hoverColor;
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

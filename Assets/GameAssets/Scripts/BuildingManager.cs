using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    #region ----------------------VARIAVEIS-v

    [SerializeField] private Transform pfWoodHarvester;
    private Camera maincamera;
    public GameObject Boje;

    #endregion ----------------------VARIAVEIS-v

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                GameObject BojeInstance;
                BojeInstance = Instantiate(Boje, hitInfo.point, Quaternion.identity) as GameObject;
            }
        }
    }
}
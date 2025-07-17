using UnityEngine;

public class PaintingInteraction : MonoBehaviour
{
    public GameObject infoPanel;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Linksklick
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    infoPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            infoPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
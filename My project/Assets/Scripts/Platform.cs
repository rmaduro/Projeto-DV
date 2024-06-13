using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    public UnityEvent<Vector3> OnClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Left mouse button clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Trigger the event with the clicked point on the platform
                OnClick.Invoke(hit.point);
            }
        }
    }
}

using System.Linq;
using UnityEngine;
using Abstractions; 

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private SelectableValue _selectedObject;  

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }

        var hits = Physics.RaycastAll(_mainCamera.ScreenPointToRay(Input.mousePosition));
        if(hits.Length == 0)
        {
            return;
        }

        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault(); 
        _selectedObject.SetValue(selectable); 
         
    }
}

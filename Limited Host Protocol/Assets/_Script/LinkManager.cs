using UnityEngine;

public class LinkManager : MonoBehaviour
{
    public IController currentController;

    private void Update()
    {
        currentController?.UpdateController();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryLink();
        }
    
    }

    void TryLink()
    {

    }


}

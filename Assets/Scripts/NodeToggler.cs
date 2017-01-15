using UnityEngine;

// Used for enabling/disabling nodes
public class NodeToggler : MonoBehaviour
{
    public GameObject[] nodesToEnable;
    public GameObject[] nodesToDisable;

    // When the game object is enabled
    void OnEnable()
    {
        EnableNodes(nodesToEnable);
        DisableNodes(nodesToDisable);
    }

    // When the game object is disabled
    void OnDisable()
    {
        EnableNodes(nodesToDisable);
        DisableNodes(nodesToEnable);
    }

    // Enable the selected nodes
    void EnableNodes(GameObject[] _nodesToEnable)
    {
        if (_nodesToEnable != null)
        {
            foreach (GameObject node in _nodesToEnable)
            {
                if (node != null)
                {
                    node.SetActive(true);
                }
            }
        }
    }

    // Disable the selected nodes
    void DisableNodes(GameObject[] _nodesToDisable)
    {
        if (_nodesToDisable != null)
        {
            foreach (GameObject node in _nodesToDisable)
            {
                node.SetActive(false);
            }
        }
    }
}

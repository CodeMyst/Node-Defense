using UnityEngine;

// This script should be attached to a node that acts as a button
public class NodeButton : MonoBehaviour
{
    // Colors of the node button
    public Color startColor;
    public Color hoverColor;

    // Store the renderer component
    private Renderer rend;

    // Used for initialization
    void Awake()
    {
        // Get the renderer component
        rend = GetComponent<Renderer>();

        // Change the color to start color
        rend.material.color = startColor;
    }

    // When the game object is enabled
    // Used when switching screens since when you switch to a screen
    // it will disable the ui, meaning it will disable the buttons
    // This will reset the button's color
    void OnEnable()
    {
        rend.material.color = startColor;
    }

    // Called when the mouse enters the collider of the object
    void OnMouseEnter()
    {
        // Change the color to hover color
        rend.material.color = hoverColor;
    }

    // Called when the mouse leaves the collider
    void OnMouseExit()
    {
        // Change the color back to the start color
        rend.material.color = startColor;
    }
}

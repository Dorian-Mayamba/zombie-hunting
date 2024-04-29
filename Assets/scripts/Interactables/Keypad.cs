using UnityEngine;

public class Keypad : Interactable
{
    // Start is called before the first frame update

    protected override void Interact()
    {
        Debug.Log("Interact with "+ gameObject.name);
    }

}

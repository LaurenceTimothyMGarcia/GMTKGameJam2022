using UnityEngine;

public abstract class InputController : ScriptableObject
{
    // Start is called before the first frame update
    public abstract float RetrieveMoveInput();
    public abstract bool RetrieveJumpInput();

    public abstract bool RetrieveJumpHoldInput();
}

using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    private CubeBehaviour _cube;

    public void ShowClick()
    {
        _cube.ShowText();
    }
    
    public void Init(CubeBehaviour cube)
    {
        _cube = cube;
    }
}
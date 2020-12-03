using UnityEngine;

namespace InputComponent
{
    public class WinInput : InputComponent
    {
        protected override void UpdateLogic()
        {
            if(Input.GetMouseButtonDown(0))
            {
                OnClickDown(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                OnClickUp();
            }

            if (!Cube) return;
            Position = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
    }
}
using UnityEngine;

namespace InputComponent
{
    public class AndroidInput : InputComponent
    {
        protected override void UpdateLogic()
        {
            if(Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    OnClickDown(Input.GetTouch(0).position);
                } else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    OnClickUp();
                }
            }
            if (!Cube) return;
            Position = new Vector2(Input.touches[0].deltaPosition.x, Input.touches[0].deltaPosition.y);
        }
        
    }
}
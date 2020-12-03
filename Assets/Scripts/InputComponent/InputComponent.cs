using UnityEngine;

namespace InputComponent
{
    public abstract class InputComponent : MonoBehaviour
    {
        protected Vector3 Position;
        protected MoveComponent Cube;
        
        private PopUp _popUp;
        private Camera _camera;

        protected void OnClickDown(Vector3 positionClick)
        {
            if (!Physics.Raycast(_camera.ScreenPointToRay(positionClick), out var hit)) return;
            Cube = hit.collider.gameObject.GetComponent<MoveComponent>();
            if (Cube != null)
                Cube.ActivateCube(_popUp.Show);
        }

        protected void OnClickUp()
        {
            if(Cube != null)
                Cube.DeactivateCube(_popUp.Show);
            Cube = null;
        }

        protected abstract void UpdateLogic();
        
        private void Awake()
        {
            _camera = Camera.main;
            _popUp = FindObjectOfType<PopUp>();
        }

        private void Update()
        {
            UpdateLogic();
            if(Cube != null)
                Cube.SetPosition(new Vector3(Position.x, 0f, Position.y));
        }
    }
}
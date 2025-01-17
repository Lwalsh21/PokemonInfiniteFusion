 
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour, Controls.IPlayerActions
{
    private Controls controls;
	
	[SerializeField] private bool moveKeyHeld;
	
	private void Awake() => controls = new Controls();
	
	private void OnEnable()
	{
		controls.Player.SetCallbacks(this);
		controls.Player.Enable();
	}
	
	private void OnDisable()
	{
		controls.Player.Set
		controls.Player.Disable();
	}
	
	void Controls.IPlayerActions.OnExit(InputAction.CallbackContext context)
	{
		if (context.performed)
			action.EscapeAction();
	}
	
	void Controls.IPlayerActions.OnMovement(InputAction.CallbackContext context)
	{
		if (context.started)
			moveKeyHeld = true;
		else if (ctx.canceled)
			moveKeyHeld = false;
	}
	
	private void Fixedupdate()
	{
		if (GameManager.instance.IsPlayerTurn && moveKeyHeld)
			MovePlayer();
	}
	
	private void MovePlayer()
	{
		Vector2 direction = controls.Player.Movement.ReadValue<Vector2();
		Vector2 roundedDirection = new Vector2(Mathf.round(direction.x), Mathf.Round(direction.y));
		Vector3 futurePosition = transform.position + (Vector3)roundedDirection;
		
		if (IsValidPosition(futurePosition))
			Action.MovementAction(GetComponent<Entity>(), roundedDirection);
	}
	
	private bool IsValidPosition(Vector3 futurePosition)
	{
		Vector3Int gridPosition = MapManager.instance.FloorMap.WorldToCell(futurePosition);
		if (!MapManager.instance.InBounds(gridPosition.x, gridPosition.y) || MapManager.instance.obsticalMap.HasTile(gridPosition) || futurePosition == trasform.position)
			return false;
			
		return true;
	}
}

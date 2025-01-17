 
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    private Controls controls;
	
	[SerializeField] private bool moveKeyHeld;
	
	private void Awake() => controls = new Controls();
	
	private void OnEnable()
	{
		controls.Enable();
		
		controls.Player.Movement.started += OnMovement;
		controls.Player.Movement.canceled += OnMpvement;
		
		controls.Players.Exit.performed += OnExit;
	}
	
	private void OnDisable()
	{
		controls.Disable();
		
		controls.Player.Movement.started -= OnMovement;
		controls.Player.Movement.canceled -= OnMovement;
		
		controls.player.Exit.performed -= OnExit;
	}
	
	private void OnMovement(InputAction.CallbackContext ctx)
	{
		if (ctx.started)
			moveKeyHeld = true;
		else if (ctx.canceled)
			moveKeyHeld = false;
	}
	
	private void OnExit(InputAction.CallbackContext ctx)
	{
		Debug.Log("Exit");
	}
	
	private void Fixedupdate()
	{
		if (GameManager.instance.IsPlayerTurn && moveKeyHeld)
			MovePlayer();
	}
	
	private void MovePlayer()
	{
		transform.position += (Vector3)controls.Player.Movement.ReadValue<Vactor2>();
		GameManager.instance.EndTurn();
	}
}

using UnityEngine;
using System.Collections;



public class SmoothFollow : MonoBehaviour
{
	public Transform target;
	public float smoothDampTime = 0.2f;
	[HideInInspector]
	public new Transform transform;
	public Vector3 cameraOffset;
	public bool useFixedUpdate = false;
	
	private CharacterController2D _playerController;
	private Vector3 _smoothDampVelocity;
	
	
	void Awake()
	{
		transform = gameObject.transform;
		_playerController = target.GetComponent<CharacterController2D>();
	}
	
	
	void LateUpdate()
	{
		if( !useFixedUpdate )
			updateCameraPosition();
	}


	void FixedUpdate()
	{
		if( useFixedUpdate )
			updateCameraPosition();
	}


	void updateCameraPosition()
	{
		if( _playerController == null )
		{
			Vector3 temp = Vector3.SmoothDamp( transform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime );
			transform.position = new Vector3(temp.x,temp.y, -10f);
			return;
		}
		
		if( _playerController.velocity.x > 0 )
		{
			//transform.position = Vector3.SmoothDamp( transform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime );
			Vector3 temp =		 Vector3.SmoothDamp( transform.position, target.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime );
			transform.position = new Vector3(temp.x,temp.y, -10f);
		}
		else
		{
			var leftOffset = cameraOffset;
			leftOffset.x *= -1;
			Vector3 temp = Vector3.SmoothDamp( transform.position, target.position - leftOffset, ref _smoothDampVelocity, smoothDampTime );
			transform.position = new Vector3(temp.x,temp.y, -10f);
		}
	}
	
}

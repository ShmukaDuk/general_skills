using UnityEngine;
using UnityEngine.Events;

public class salamiMovement : MonoBehaviour
{
                     
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = false;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;	

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	    public void Move(float move)
	{
		Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
		if (move > 0 && !m_FacingRight)
		{		
			m_FacingRight = !m_FacingRight;
			transform.Rotate(0f, 180f, 0);
		}		
		else if (move < 0 && m_FacingRight)
		{
			
			m_FacingRight = !m_FacingRight;
			transform.Rotate(0f, 180f, 0);
		}


		
		
		

	}
}

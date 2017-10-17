using UnityEngine;

public class MeteoriteController : TouchableObjectController
{
	public void SetGravityScale(float gs)
    {
        rb.gravityScale = gs;
    }
}


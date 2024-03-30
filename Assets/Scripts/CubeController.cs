///-------------------------------------------------------------------------------------------------
///
/// \file CubeController.cs
/// \brief Main Controller to manage the cube.
/// \author Thibaut Monseigne.
/// \version 1.0.
/// \date 27/03/2024.
/// \copyright <a href="https://choosealicense.com/licenses/mit/">MIT License</a>.
///
///-------------------------------------------------------------------------------------------------

using UnityEngine;

public class CubeController : MonoBehaviour
{
	#region Members
	// Color Management
	private Material material;
	private static readonly int ColNameId = Shader.PropertyToID("_Color");
	private readonly Color[] colors = { Color.blue, Color.cyan, Color.green, Color.yellow, Color.red, Color.magenta };
	private int colPos = 0;
	// Scale Management
	private float scale = 1.0F;
	private static readonly float scaleMax = 5.0F;
	private static readonly float scaleMin = 0.5F;
	// Rotation Management
	private static readonly Vector3 rotationAxis = new Vector3(10.0F, 10.0F, 10.0F);
	private int speed = 1;
	private static readonly int speedMax = 25;
	#endregion

	#region Controller Functions
	/// <summary> Start is called before the first frame update. </summary>
	private void Start()
	{
		material = GetComponent<Renderer>().material;
		material.SetColor(ColNameId, colors[colPos]);
	}

	///<summary> Update is called once per frame. </summary>
	void Update()
	{
		// Check Escape Input
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }

		// Change Scale
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			scale += 0.2F;
			if (scale >= scaleMax) { scale = scaleMax; }
			transform.localScale = new Vector3(scale, scale, scale);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			scale -= 0.2F;
			if (scale < scaleMin) { scale = scaleMin; }
			transform.localScale = new Vector3(scale, scale, scale);
		}

		// Change Speed
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			speed++;
			if (speed >= speedMax) { speed = speedMax; }
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			speed--;
			if (speed < -speedMax) { speed = -speedMax; }
		}

		// Rotate the cube
		transform.Rotate(rotationAxis * Time.deltaTime * speed);

		// Change Color
		if (Input.GetKeyDown(KeyCode.Space)) {
			colPos++;
			if (colPos >= colors.Length) { colPos = 0; }
			material.SetColor(ColNameId, colors[colPos]);
		}
	}
	#endregion
}

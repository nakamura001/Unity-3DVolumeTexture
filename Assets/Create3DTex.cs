using UnityEngine;
     
public class Create3DTex : MonoBehaviour
{
       
	private Texture3D tex;
	public int size = 16;
     
	void Start ()
	{
		tex = new Texture3D (size, size, size, TextureFormat.ARGB32, true);
		var cols = new Color[size * size * size];
		float mul = 1.0f / (size - 1);
		int idx = 0;
		Color c = Color.white;
		for (int z = 0; z < size; ++z) {
			for (int y = 0; y < size; ++y) {
				for (int x = 0; x < size; ++x, ++idx) {
					c.r = 1f - (Mathf.Abs(x-size * .5f) * 2f * mul);
					c.g = 1f - (Mathf.Abs(y-size * .5f) * 2f * mul);
					c.b = 1f - (Mathf.Abs(z-size * .5f) * 2f * mul);
					cols [idx] = c;
				}
			}
		}
		tex.SetPixels (cols);
		tex.Apply ();
		renderer.material.SetTexture ("_Volume", tex);
	}   
}
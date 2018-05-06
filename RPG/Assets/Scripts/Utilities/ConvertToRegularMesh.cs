using UnityEngine;

/*
 * Converts SkinnedMeshRenderers into the regular form of MeshRenderer & MeshFilter combo
 * Used to easily convert between items on the ground to pickup, and equipment on the body
 * 
 * Add component to object and right click context menu to use
 */

public class ConvertToRegularMesh : MonoBehaviour
{
    [ContextMenu("Convert to Regular Mesh")]
	void Convert()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        //Set mesh and materials so they don't change through the conversion
        meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;

        //Delete the SkinnedMeshRenderer & this script after conversion
        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}

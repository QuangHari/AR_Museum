namespace CreateImageTarget {
using UnityEngine;
using Vuforia;

public class GenerateImageTarget
{
    public Texture2D markerTexture;
    public string targetName;

    public void Start()
    {


        // Create a new Image Target
        ImageTargetBehaviour imageTarget = CreateImageTarget(targetName);
        Debug.Log("Created image target");
        // Set the image target texture
        // SetImageTargetTexture(imageTarget, markerTexture);
    }

    public GenerateImageTarget(Texture2D _markerTexture, string _targetName){
        markerTexture = _markerTexture;
        targetName = _targetName;
    }

    ImageTargetBehaviour CreateImageTarget(string targetName)
    {
        // Create an empty GameObject and add the ImageTargetBehaviour component
        
        // Load the ImageTarget prefab
        GameObject imageTargetPrefab = Resources.Load<GameObject>("ImageTargetPrefab");

        // Instantiate the prefab
        GameObject targetObject = Object.Instantiate(imageTargetPrefab);
        targetObject.name = targetName;
        // ImageTargetBehaviour imageTargetBehaviour = targetObject.AddComponent<ImageTargetBehaviour>();

        // Set the trackable name
        // TrackableBehaviour trackableBehaviour = imageTargetBehaviour as TrackableBehaviour;
        // if (trackableBehaviour != null)
        // {
        //     trackableBehaviour.TrackableName = targetName;
        // }

        // Attach the GameObject to the DefaultTrackableEventHandler
        // DefaultTrackableEventHandler trackableEventHandler = targetObject.AddComponent<DefaultTrackableEventHandler>();
        // trackableEventHandler.OnTrackableStateChanged += OnTrackableStateChanged;

        // Activate the Image Target
        // imageTargetBehaviour.gameObject.SetActive(true);

        return null;
    }


    // void SetImageTargetTexture(ImageTargetBehaviour imageTarget, Texture2D texture)
    // {
    //     // Create a new virtual button in the Image Target
    //     // VirtualButtonBehaviour[] virtualButtons = imageTarget.gameObject.GetComponentsInChildren<VirtualButtonBehaviour>();
    //     // foreach (VirtualButtonBehaviour virtualButton in virtualButtons)
    //     // {
    //     //     virtualButton.enabled = false;
    //     // }

    //     // Create a new ImageTargetBehaviour and set the texture
    //     ImageTargetBehaviour imageTargetBehaviour = imageTarget.GetComponent<ImageTargetBehaviour>();
    //     if (imageTargetBehaviour != null)
    //     {
    //         imageTargetBehaviour.enabled = true;
    //         imageTargetBehaviour.InitializeImage(texture);
    //     }
    // }

    // void OnTrackableStateChanged(bool isTracked)
    // {
    //     Debug.Log("Target " + (isTracked ? "found" : "lost"));
    //     // Perform any desired actions when the target is tracked or lost
    // }
}
}


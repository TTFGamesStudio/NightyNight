using UnityEngine;
using UnityEngine.Events;

namespace NightNightEngine.Player
{
    /// <summary>
    /// The look At class is only used by the player object to get data for interacting with the world
    /// for raycasting / lookAt data for non player entities please use the lineTrace script instead.
    /// </summary>
    public class LookAt : MonoBehaviour
    {
        /// <summary>
        /// What Kind of Objects (Defined by layer) do we want to be able store
        /// </summary>
        [SerializeField] private LayerMask lookAtMask;

        /// <summary>
        /// The object we foudn (null if no object)
        /// </summary>
        [SerializeField] private GameObject lookAtObject;

        /// <summary>
        /// The camera we are using for origin and forward
        /// </summary>
        [SerializeField] private Transform camera;

        /// <summary>
        /// How far forward do we want to be able to look?
        /// </summary>
        [SerializeField] private float distance;


        public UnityEvent<string> lookAtEvent;
        public UnityEvent endLookEvent;

        private void Update()
        {
            if (!GameManager.instance.gamePaused)
            {
                Raycast();
                if (lookAtObject != null && Input.GetKeyUp(KeyCode.E))
                {

                    lookAtObject.SendMessage("trigger", SendMessageOptions.DontRequireReceiver);
                }
            }
        }

        /// <summary>
        /// Preform the raycast to check for object, stores any result in lookAtObject (GameObject)
        /// </summary>
        void Raycast()
        {
            Ray r = new Ray(camera.position, camera.forward);
            if (Physics.Raycast(r, out RaycastHit hit, distance, lookAtMask))
            {
                if (lookAtObject == null || lookAtObject != hit.collider.gameObject)
                {
                    if(hit.collider.gameObject.GetComponent<LookAtData>()!=null)
                        lookAtEvent?.Invoke(hit.collider.gameObject.GetComponent<LookAtData>().TextToDisplay);
                    else
                    {
                        Debug.LogError("attempted to get look at info from an object without a look at data component, add component to " + hit.transform.name);
                    }
                }
                lookAtObject = hit.collider.gameObject;
                
            }
            else
            {
                if (lookAtObject != null )
                {
                    endLookEvent?.Invoke();
                }
                lookAtObject = null;
            }
        }

        /// <summary>
        /// get the looked at object (if one is available) for external classes
        /// </summary>
        public GameObject GetLookAt()
        {
            return lookAtObject;
        }
    }
}

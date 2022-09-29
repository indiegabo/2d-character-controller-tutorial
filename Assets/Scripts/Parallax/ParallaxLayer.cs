using UnityEngine;

namespace H2DT.Environmental
{

    [AddComponentMenu("Handy 2D Tools/Platformer/Environmental/Parallax/ParallaxLayer")]
    [RequireComponent(typeof(SpriteRenderer))]
    public class ParallaxLayer : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        protected Parallax parallax;

        [SerializeField]
        protected ParallaxLayerType layerType = ParallaxLayerType.Background;

        [Tooltip("In case you want to override the auto arrange and keep the position of this particular layer")]
        [SerializeField]
        protected bool keepPosition = false;

        [Header("Speed Factor")]
        [SerializeField]
        protected bool overrideSpeedFactor = false;

        [SerializeField]
        protected Vector2 speedFactor = new Vector2(1f, 1f);

        [Header("Update Mode")]
        [SerializeField]
        protected bool overrideUpdateMode = false;

        #endregion

        #region Fields

        protected SpriteRenderer spriteRenderer;
        protected Vector3 referencePos;
        protected float textureUnitSizeX;

        #endregion

        #region Properties

        // Overrides
        protected Vector2 SpeedFactor => overrideSpeedFactor ? speedFactor : parallax.SpeedFactor;

        // Distances from the subject
        protected float TravelX => parallax.Camera.transform.position.x - referencePos.x;
        protected float TravelY => parallax.Camera.transform.position.y - referencePos.y;

        // Calculating the parallax factor
        protected float DistanceFromSubject => referencePos.z - parallax.Subject.transform.position.z;
        protected float ClipPlane => parallax.Camera.transform.position.z + (DistanceFromSubject > 0 ? parallax.Camera.farClipPlane : -parallax.Camera.nearClipPlane);
        protected float ParallaxFactor => (Mathf.Abs(DistanceFromSubject) / ClipPlane);

        // Calculating new positions
        protected float xCalc => !parallax.LockX ? referencePos.x + (TravelX * ParallaxFactor * SpeedFactor.x) : referencePos.x;
        protected float yCalc => !parallax.LockY ? referencePos.y + (TravelY * ParallaxFactor * SpeedFactor.y) : referencePos.y;

        // What value should be used as an update
        protected float NewX => parallax.On ? xCalc : transform.position.x;
        protected float NewY => parallax.On ? yCalc : transform.position.y;

        #endregion

        #region Getters

        public ParallaxLayerType LayerType => layerType;
        public bool KeepPosition => keepPosition;

        #endregion

        #region Mono

        protected virtual void Awake()
        {
            if (parallax == null)
                parallax = GetComponentInParent<Parallax>();

            if (parallax == null)
                Debug.LogError($"{gameObject.name} is not attached to a Parallax object!");

            spriteRenderer = GetComponent<SpriteRenderer>();

            if (parallax != null && parallax.GrowLayers)
            {
                spriteRenderer.drawMode = SpriteDrawMode.Tiled;
                spriteRenderer.size = new Vector2(spriteRenderer.bounds.size.x * 3, spriteRenderer.size.y);
            }

            textureUnitSizeX = spriteRenderer.sprite.texture.width / spriteRenderer.sprite.pixelsPerUnit;
        }

        protected virtual void FixedUpdate()
        {
            Apply();
        }

        #endregion

        protected virtual void Apply()
        {
            transform.position = new Vector3(NewX, NewY, referencePos.z);

            EvaluateAndSnapToCamera();
        }

        protected virtual void EvaluateAndSnapToCamera()
        {
            if (!parallax.Infinite) return;

            float cameraDistance = parallax.Camera.transform.position.x - transform.position.x;

            if (Mathf.Abs(cameraDistance) >= textureUnitSizeX)
            {
                float offsetPositionX = cameraDistance % textureUnitSizeX;
                referencePos.x = parallax.Camera.transform.position.x - offsetPositionX;
                if (layerType == ParallaxLayerType.Background)
                {
                    transform.position = new Vector3(parallax.Camera.transform.position.x + offsetPositionX, transform.position.y, referencePos.z);
                }
                else if (layerType == ParallaxLayerType.Foreground)
                {
                    transform.position = new Vector3(parallax.Camera.transform.position.x - offsetPositionX, transform.position.y, referencePos.z);
                }
            }
        }

        public void SetReferencePos(Vector3 pos)
        {
            referencePos = pos;
        }

    }
}

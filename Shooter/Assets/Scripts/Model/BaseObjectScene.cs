using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public abstract class BaseObjectScene : MonoBehaviour
    {
        private int _baseLayer;
        private bool _isVisible;
        private Vector3 _center;
        protected Color BaseColor;
        protected Transform BaseTransform;
        protected GameObject BaseGameObject;
        protected Material BaseMaterial;
        protected Quaternion BaseRotation;
        protected Rigidbody BaseRigidBody;

        #region UnityMethods
        protected virtual void Awake()
        {
            BaseGameObject = gameObject;
            BaseTransform = transform;
            _baseLayer = gameObject.layer;
            RigidBody = GetComponent<Rigidbody>();
            if (GetComponent<Renderer>())
            {
                BaseMaterial = GetComponent<Material>();
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Получить или установить номер слоя объекта
        /// </summary>
        public int LayerProperty
        {
            get
            {
                return _baseLayer;
            }

            set
            {
                _baseLayer = value;

                AskLayer(BaseTransform, _baseLayer);
            }
        }

        /// <summary>
        /// Получить материал объекта
        /// </summary>
        public Material GetMaterial
        {
            get
            {
                return BaseMaterial;
            }
        }

        /// <summary>
        /// Получить или установить цвет объекта
        /// </summary>
        public Color ColorProperty
        {
            get
            {
                return BaseColor;
            }

            set
            {
                BaseColor = value;
                AskColor(BaseTransform, BaseColor);
            }
        }

        /// <summary>
        /// Включает или выключает объект
        /// </summary>
        public bool Visible
        {
            get { return _isVisible; }

            set
            {
                _isVisible = value;
                var temporaryRenderer = BaseGameObject.GetComponent<Renderer>();

                if (temporaryRenderer)
                    temporaryRenderer.enabled = _isVisible;

                if (BaseTransform.childCount <= 0) return;
                foreach (Transform a in BaseTransform)
                {
                    temporaryRenderer = a.gameObject.GetComponent<Renderer>();
                    if(temporaryRenderer)
                        temporaryRenderer.enabled = _isVisible;
                }
            }
        }

        public Vector3 Center
        {
            get
            {
                var renderers = BaseGameObject.GetComponentInChildren<Renderer>();
                var bounds = renderers.bounds;
                return _center;
            }
        }

        public Rigidbody RigidBody
        {
            get { return BaseRigidBody; }
            set { BaseRigidBody = value; }
        }

        #endregion

        #region ClassMethods
        /// <summary>
        /// Выставляет слой себе и всем дочерним объектам.
        /// </summary>
        /// <param name="childrenTransform">Объект</param>
        /// <param name="numberLayer">Слой</param>
        private void AskLayer(Transform childrenTransform, int numberLayer)
        {
            childrenTransform.gameObject.layer = numberLayer;

            if (childrenTransform.childCount == 0) return;

            foreach (Transform children in childrenTransform)
            {
                AskLayer(children, numberLayer);
            }
        }

        /// <summary>
        /// Устанавливает цвет материала себе и всем дочерним объектам.
        /// </summary>
        /// <param name="childrenTransform"></param>
        /// <param name="nameColor"></param>
        private void AskColor(Transform childrenTransform, Color nameColor)
        {
            // Если объект один - присваиваем цвет ему.
            if (BaseMaterial != null)
                BaseMaterial.color = BaseColor;

            if (childrenTransform.childCount == 0) return;

            // Если есть дочерние объекты - проходимся и устанавливаем цвет каждому.
            for (var i = 0; i < childrenTransform.childCount; i++)
            {   
                if(childrenTransform.GetChild(i).GetComponent<Renderer>())
                    childrenTransform.GetChild(i).GetComponent<Renderer>().material.color = nameColor;
            }
        }

        /// <summary>
        /// Базовая корутина для возможной перезарядки всех типов предметов персонажа.
        /// </summary>
        /// <param name="time">Время перезарядки</param>
        /// <returns></returns>
        protected virtual IEnumerator CoolDown(int time)
        {
            yield return time;
        }

        #endregion
    }
}

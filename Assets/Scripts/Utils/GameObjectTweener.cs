namespace AshkolTools.UI
{
    using UnityEngine;
    using UnityEngine.Events;

    public enum AnimationType
    {
        Move,
        MoveAbsolute,
        Scale,
        ScaleX,
        ScaleY,
        Fade,
        RotateX,
        RotateY,
        RotateZ
    }


    public class GameObjectTweener : MonoBehaviour
    {
        public GameObject objectToAnimate;

        public AnimationType animationType;
        public LeanTweenType easeType;
        public float duration;
        public float delay;

        public bool loop;
        public bool pingpong;

        public bool startPositionOffset;
        public Vector3 from;
        public Vector3 to;

        private LTDescr _tweenObject;

        public bool showOnEnable;
        public bool workOnDisable;

        private void Start()
        {
            LeanTween.rotateX(objectToAnimate, to.x, duration);
            //if (showOnEnable)
            //{
            //    Show();
            //}
        }

        public void Show()
        {
            Debug.Log("SHOW");
            HandleTween();
        }

        //IEnumerator HandleTweenDelayed()
        //{
        //    float counter = 0;
        //    while (counter < delay)
        //    {
        //        counter += Time.deltaTime;
        //        yield return null;
        //    }
        //    HandleTween();
        //}

        //IEnumerator Activate()
        //{
        //    float counter = 0;
        //    while (counter < delay)
        //    {
        //        counter += Time.deltaTime;
        //        yield return null;
        //    }
        //    objectToAnimate.SetActive(true);
        //}

        public void HandleTween()
        {
            if (objectToAnimate == null)
            {
                objectToAnimate = gameObject;
            }

            switch (animationType)
            {
                case AnimationType.Fade:
                    Fade();
                    break;
                case AnimationType.Move:
                    Move();
                    break;
                case AnimationType.MoveAbsolute:
                    MoveAbsolute();
                    break;
                case AnimationType.Scale:
                    Scale();
                    break;
                case AnimationType.ScaleX:
                    ScaleX();
                    break;
                case AnimationType.ScaleY:
                    ScaleY();
                    break;
                case AnimationType.RotateX:
                    RotateX();
                    break;
                case AnimationType.RotateY:
                    RotateY();
                    break;
                case AnimationType.RotateZ:
                    RotateZ();
                    break;
                default:
                    break;
            }

            _tweenObject.setDelay(delay);
            _tweenObject.setEase(easeType);

            if (loop)
            {
                _tweenObject.loopCount = int.MaxValue;
            }
            if (pingpong)
            {
                _tweenObject.setLoopPingPong();
            }
        }

        public void HandleTween(float delay)
        {
            if (objectToAnimate == null)
            {
                objectToAnimate = gameObject;
            }

            switch (animationType)
            {
                case AnimationType.Fade:
                    Fade();
                    break;
                case AnimationType.Move:
                    Move();
                    break;
                case AnimationType.MoveAbsolute:
                    MoveAbsolute();
                    break;
                case AnimationType.Scale:
                    Scale();
                    break;
                case AnimationType.ScaleX:
                    ScaleX();
                    break;
                case AnimationType.ScaleY:
                    ScaleY();
                    break;
                case AnimationType.RotateX:
                    RotateX();
                    break;
                case AnimationType.RotateY:
                    RotateY();
                    break;
                case AnimationType.RotateZ:
                    RotateZ();
                    break;
                default:
                    Debug.Log("default:");
                    break;
            }

            _tweenObject.setDelay(delay);
            _tweenObject.setEase(easeType);

            if (loop)
            {
                _tweenObject.loopCount = int.MaxValue;
            }
            if (pingpong)
            {
                _tweenObject.setLoopPingPong();
            }
        }

        public void Fade()
        {
            if (gameObject.GetComponent<CanvasGroup>() == null)
            {
                gameObject.AddComponent<CanvasGroup>();
            }

            if (startPositionOffset)
            {
                objectToAnimate.GetComponent<CanvasGroup>().alpha = from.x;
            }
            _tweenObject = LeanTween.alphaCanvas(objectToAnimate.GetComponent<CanvasGroup>(), to.x, duration);
        }

        public void MoveAbsolute()
        {
            objectToAnimate.GetComponent<Transform>().localPosition = from;
            _tweenObject = LeanTween.move(objectToAnimate, to, duration);
        }

        public void Move()
        {
            objectToAnimate.GetComponent<Transform>().localPosition = from;
            _tweenObject = LeanTween.moveLocal(objectToAnimate, to, duration);
        }

        public void Scale()
        {
            if (startPositionOffset)
            {
                objectToAnimate.GetComponent<Transform>().localScale = from;
            }
            _tweenObject = LeanTween.scale(objectToAnimate, to, duration);
        }

        public void ScaleX()
        {
            if (startPositionOffset)
            {
                objectToAnimate.GetComponent<Transform>().localScale = from;
            }
            _tweenObject = LeanTween.scaleX(objectToAnimate, to.x, duration);
        }

        public void ScaleY()
        {
            if (startPositionOffset)
            {
                objectToAnimate.GetComponent<Transform>().localScale = from;
            }
            _tweenObject = LeanTween.scaleY(objectToAnimate, to.y, duration);
        }

        public void RotateX()
        {
            Debug.Log("RotateX()");
            if (startPositionOffset)
            {
                objectToAnimate.GetComponent<Transform>().eulerAngles = from;
            }
            _tweenObject = LeanTween.rotateX(objectToAnimate, to.x, duration);
        }

        public void RotateY()
        {
            Debug.Log("RotateY()");
            if (startPositionOffset)
            {
                objectToAnimate.GetComponent<Transform>().eulerAngles = from;
            }
            _tweenObject = LeanTween.rotateY(objectToAnimate, to.y, duration);
        }

        public void RotateZ()
        {
            Debug.Log("RotateZ()");
            if (startPositionOffset)
            {
                objectToAnimate.GetComponent<Transform>().eulerAngles = from;
            }
            _tweenObject = LeanTween.rotateZ(objectToAnimate, to.z, duration);
        }

        public void SwapDirection()
        {
            var temp = from;
            from = to;
            to = temp;
        }

        public void Disable()
        {
            SwapDirection();
            HandleTween();
            _tweenObject.setOnComplete(() =>
            {
                SwapDirection();
                //gameObject.SetActive(false);
            });
        }

        public void DisableImmediate()
        {
            float activeDelay = delay;
            delay = 0f;
            SwapDirection();
            HandleTween();
            _tweenObject.setOnComplete(() =>
            {
                SwapDirection();
                gameObject.SetActive(false);
            });
            delay = activeDelay;
        }

        public void Disable(UnityAction onCompleteAction)
        {
            SwapDirection();
            HandleTween();
            _tweenObject.setOnComplete(() =>
            {
                SwapDirection();
                gameObject.SetActive(false);
                onCompleteAction.Invoke();
            });
        }
    }

}

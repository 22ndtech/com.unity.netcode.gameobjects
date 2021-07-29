using MLAPI.Timing;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "NoInterpolationVector3", menuName = BaseMenuName + "NoInterpolationVector3", order = 1)]
    public class NoInterpolationVector3Factory : InterpolatorFactory<Vector3>
    {
        public override IInterpolator<Vector3> CreateInterpolator()
        {
            return new NoInterpolation<Vector3>();
        }
    }

    [CreateAssetMenu(fileName = "NoInterpolationQuaternion", menuName = BaseMenuName + "NoInterpolationQuaternion", order = 1)]
    public class NoInterpolationQuaternionFactory : InterpolatorFactory<Quaternion>
    {
        public override IInterpolator<Quaternion> CreateInterpolator()
        {
            return new NoInterpolation<Quaternion>();
        }
    }

    public class NoInterpolation<T> : IInterpolator<T>
    {
        private T m_Current;

        public void Update(float deltaTime)
        {
            // nothing
        }

        public void NetworkTickUpdate(float fixedDeltaTime)
        {
        }

        public void AddMeasurement(T newMeasurement, NetworkTime sentTick)
        {
            m_Current = newMeasurement;
        }

        public T GetInterpolatedValue()
        {
            return m_Current;
        }

        public void Reset(T value, NetworkTime SentTick)
        {
            m_Current = value;
        }
    }
}
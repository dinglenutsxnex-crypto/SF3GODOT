using Nekki.Yaml;
using SF3.Effects;
using UnityEngine;

namespace SF3.Moves
{
	public class TriggerActionShakeCamera : TriggerAction
	{
		private readonly Vector3 _amplitude;

		private readonly RpnValue<int> _duration;

		private readonly Vector3 _period;

		public Vector3 Amplitude
		{
			get
			{
				return _amplitude;
			}
		}

		public int Duration
		{
			get
			{
				return _duration;
			}
		}

		public Vector3 Period
		{
			get
			{
				return _period;
			}
		}

		public TriggerActionShakeCamera(Node yamlNode)
			: base(EActionType.SHAKE_CAMERA, yamlNode)
		{
			if (!(yamlNode is Scalar))
			{
				string outResult;
				if (TryGetString(out outResult, "Frames", string.Empty, string.Empty, null, false))
				{
					_duration = outResult;
				}
				else
				{
					_duration = 0;
				}
				float amplitudeX = 0f, amplitudeY = 0f, amplitudeZ = 0f;
				float periodX = 0f, periodY = 0f, periodZ = 0f;
				TryGetFloat(out amplitudeX, "AmpX", 0f, string.Empty, null, false);
				TryGetFloat(out amplitudeY, "AmpY", 0f, string.Empty, null, false);
				TryGetFloat(out amplitudeZ, "AmpZ", 0f, string.Empty, null, false);
				TryGetFloat(out periodX, "PeriodX", 0f, string.Empty, null, false);
				TryGetFloat(out periodY, "PeriodY", 0f, string.Empty, null, false);
				TryGetFloat(out periodZ, "PeriodZ", 0f, string.Empty, null, false);
				_amplitude = new Vector3(amplitudeX, amplitudeY, amplitudeZ);
				_period = new Vector3(periodX, periodY, periodZ);
			}
		}

		protected override void ApplyAction(object modelData)
		{
			base.ApplyAction(modelData);
			EffectsManager.PlayEffect(base.name, this);
		}
	}
}

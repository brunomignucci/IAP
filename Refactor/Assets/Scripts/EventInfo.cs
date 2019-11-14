using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
	public class EventInfo
	{
		public string EventDescription;
	}

	public class TouchEventInfo : EventInfo
	{
		public GameObject TouchedGameObject;
	}
}

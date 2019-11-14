using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
	public class EventSystem : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{

		}

		static private EventSystem __Current;
		static public EventSystem Current
		{
			get
			{
				if(__Current == null)
				{
					__Current = GameObject.FindObjectOfType<EventSystem>();
				}
				return __Current;
			}
		}

		public delegate void EventListener(EventInfo ei);
		public enum EVENT_TYPE { TOUCH, PRESS }
		Dictionary<EVENT_TYPE, List<EventListener>> eventListeners;


		public void RegisterListener(EVENT_TYPE eventType, EventListener listener)
		{
			if(eventListeners == null)
			{
				eventListeners = new Dictionary<EVENT_TYPE, List<EventListener>>();
			}
			if(eventListeners.ContainsKey(eventType) == false || eventListeners[eventType] == null)
			{
				eventListeners[eventType] = new List<EventListener>();
			}
			eventListeners[eventType].Add(listener);
		}

		public void UnretisterListener(EVENT_TYPE eventType, EventListener listener)
		{
			//TODO
		}

		public void FireEvent(EVENT_TYPE eventType, EventInfo eventInfo)
		{
			if( eventListeners == null || eventListeners[eventType] == null )
			{
				return;
			}
			foreach(EventListener el in eventListeners[eventType])
			{
				el(eventInfo);
			}
		}

	}

}
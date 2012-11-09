﻿using System;
using System.Collections.Generic;

namespace Microsoft.AspNet.SignalR.Tests.Server
{
    public class TestSubscriber : ISubscriber
    {
        public TestSubscriber(IEnumerable<string> keys)
        {
            EventKeys = keys;
            Identity = Guid.NewGuid().ToString();
        }

        public IEnumerable<string> EventKeys { get; private set; }

        public string Identity { get; private set; }

        public event Action<string> EventAdded;

        public event Action<string> EventRemoved;

        public Func<string> GetCursor { get; set; }

        public void AddEvent(string eventName)
        {
            if (EventAdded != null)
            {
                EventAdded(eventName);
            }
        }

        public void RemoveEvent(string eventName)
        {
            if (EventRemoved != null)
            {
                EventRemoved(eventName);
            }
        }
    }
}

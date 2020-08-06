using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteController.Web.Hubs
{
    public class HubMannager<T>
    {
        private readonly HashSet<string> _connections = new HashSet<string>();

        public int Count
        {
            get
            {
                lock (_connections)
                {
                    return (int) _connections?.Count;
                }
            }
        }

        public void Add(string connectionId)
        {
            lock (_connections)
            {
                if (connectionId != null && _connections.All(c => c != connectionId))
                {
                    _connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(string connectionId)
        {
            lock (_connections)
            {
                return _connections.Count > 0 ? _connections : Enumerable.Empty<string>();
            }
        }

        public void Remove(string connectionId)
        {
            lock (_connections)
            {
                if (_connections.All(c => c != connectionId))
                {
                    return;
                }

                _connections.Remove(connectionId);
            }
        }
    }
}

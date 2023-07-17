using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITesting
{
    public class Blackboard
    {
        private readonly object _lockObject = new object();

        private Dictionary<string, dynamic> _map = new Dictionary<string, dynamic>();

        private Blackboard _parent = null;
        private Dictionary<string, Blackboard> _children = new Dictionary<string, Blackboard>();

        public Blackboard(Blackboard parent = null)
        {
            _parent = parent;
        }

        public  Result<Blackboard> Create(string name)
        {
            lock (_lockObject)
            {
                if (_children.ContainsKey(name)) { Result.Fail($"Blackboard {name} already exists.");  }
                var bb = new Blackboard(this);
                _children[name] = bb;
                return Result.Ok(bb);
            }
        }

        public Result<T> Get<T>(string name)
        {
            lock (_lockObject)
            {
                if (! _map.ContainsKey(name)) 
                {
                    if (_parent == null) return Result.Fail($"Key {name} not found");
                    return _parent.Get<T>(name); 
                }
                var result = _map[name];
                if (result is T) return Result.Ok((T)result);
                return Result.Fail($"Value of {name} is not type {typeof(T).Name}");
            }
        }

        public Result<T> Set<T>(string name, T value)
        {
            lock (_lockObject)
            {
                if (! _map.ContainsKey(name)) 
                { 
                    _map.Add(name, value);
                    return Result.Ok(value);
                } else
                {
                    _map[name] = value;
                    return Result.Ok(value);
                }
            }
        }

    }
}

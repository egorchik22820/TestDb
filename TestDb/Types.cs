using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDb
{
    internal class Types
    {
        private string _typeName;
        private int _typeId;
        private double _typeCoaf;
        public string TypeName { get => _typeName; }
        public int TypeId { get => _typeId; }
        public Types(string typeName, int typeId)
        {
            _typeName = typeName;
            _typeId = typeId;
        }
        public override string ToString()
        {
            return _typeName;
        }
    }
}

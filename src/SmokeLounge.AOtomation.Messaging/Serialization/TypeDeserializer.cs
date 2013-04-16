using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeLounge.AOtomation.Messaging.Serialization
{
    public class TypeDeserializer
    {
        private readonly Type type;

        private Func<StreamReader, object> deserializer;

        public TypeDeserializer(Type type)
        {
            this.type = type;
            if (this.type.IsAbstract)
            {
                this.deserializer = _ => null;
                return;
            }

            var constructorInfo = this.type.GetConstructor(null);
            if (constructorInfo == null)
            {
                this.deserializer = _ => null;
                return;
            }


            var properties = this.type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var aoMember = propertyInfo.GetCustomAttributes(typeof(AoMemberAttribute), false).Cast<AoMemberAttribute>().FirstOrDefault();

            }
        }

        public object Deserialize(StreamReader reader)
        {
            return null;
        }
    }
}

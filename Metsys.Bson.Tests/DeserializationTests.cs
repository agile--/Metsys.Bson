using Xunit;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Metsys.Bson.Tests
{
    public class DeserializationTests
    {
        [Fact]
        public void DeserializesAnInteger()
        {
            var input = Serializer.Serialize(new {Int = 72});
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(72, o.Int);
        }
        [Fact]
        public void DeserializesALong()
        {
            var input = Serializer.Serialize(new { Long = 993l });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(993, o.Long);
        }
        [Fact]
        public void DeserializesAFloat()
        {
            var input = Serializer.Serialize(new { Float = 1003.324f });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(1003.324f, o.Float);
        }
        [Fact]
        public void DeserializesADouble()
        {
            var input = Serializer.Serialize(new { Double = 1003.324 });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(1003.324, o.Double);
        }
        [Fact]
        public void DeserializesAString()
        {
            var input = Serializer.Serialize(new { String = "Its Over 9000!" });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal("Its Over 9000!", o.String);
        }
        [Fact]
        public void DeserializesAGuid()
        {
            var guid = Guid.NewGuid();
            var input = Serializer.Serialize(new { Guid = guid });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(guid, o.Guid);
        }
        [Fact]
        public void DeserializesAByteArray()
        {
            var array = new byte[] {1, 2, 3, 100, 94};
            var input = Serializer.Serialize(new { ByteArray = array });
            var o = Deserializer.Deserialize<Fatty>(input);            
            Assert.Equal(array, o.ByteArray);
        }
        [Fact]
        public void DeserializesADateTime()
        {
            var date = new DateTime(2001, 4, 8, 10, 43, 23, 104);
            var input = Serializer.Serialize(new { DateTime = date });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(date, o.DateTime);
        }
        [Fact]
        public void DeserializesARegex()
        {
            var regex = new Regex("its over (\\d+?)", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            var input = Serializer.Serialize(new { Regex = regex });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(regex.ToString(), o.Regex.ToString());
            Assert.Equal(regex.Options, o.Regex.Options);
        }
        [Fact]
        public void DeserializesAnArray()
        {
            var array = new object[] { 1, "a" };
            var input = Serializer.Serialize(new { Array = array });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(array, o.Array);
        }
        [Fact]
        public void DeserializesAList()
        {
            var list = new List<string> {"a", "ouch"};
            var input = Serializer.Serialize(new { List = list });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(list, o.List);
        }
        [Fact]
        public void DeserializesADictionary()
        {
            var dictionary = new Dictionary<string, object> {{"fiRst", 1}, {"second", "tWo"}};
            var input = Serializer.Serialize(new { Dictionary = dictionary });
            var o = Deserializer.Deserialize<Fatty>(input);
            Assert.Equal(1, o.Dictionary["fiRst"]);
            Assert.Equal("tWo", o.Dictionary["second"]);
        }        
    }
}
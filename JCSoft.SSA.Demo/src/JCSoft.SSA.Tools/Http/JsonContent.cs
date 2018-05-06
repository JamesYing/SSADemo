using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace JCSoft.SSA.Tools.Http
{
    public class JsonContent : StringContent
    {
        public JsonContent(string content) : this(content, Encoding.UTF8)
        {
        }

        public JsonContent(string content, Encoding encoding) : this(content, encoding, "application/json") { }

        public JsonContent(string content, Encoding encoding, string mediaType) : base(content, encoding, mediaType) { }
    }
}

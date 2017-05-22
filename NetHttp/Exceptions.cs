using System;

namespace NetHttp
{
    public class DeserialisationException : Exception
    {
        public DeserialisationException(Exception exception) : base("Deserialisation of body failed. See inner exception.",exception)
        {

        }
    }

    public class ContentReadException : Exception
    {
        public ContentReadException(Exception exception) : base("Content cannot be read. See inner exception.", exception)
        {
                
        }
    }
}

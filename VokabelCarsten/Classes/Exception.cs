using System;

[Serializable()]
public class FileNotReadException : System.Exception
{
    public FileNotReadException() : base() { }
    public FileNotReadException(string message) : base(message) { }
    public FileNotReadException(string message, System.Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an
    // exception propagates from a remoting server to the client. 
    protected FileNotReadException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
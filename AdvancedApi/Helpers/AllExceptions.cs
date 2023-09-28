namespace AdvancedApi.Helpers
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(string message) : base(message) { }
    }

    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message) : base(message) { }
    }

    public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message) { }
    }

    public class CannotInsertNull : Exception
    {
        public CannotInsertNull(string message) : base(message) { }
    }

    public class CannotInsertDuplicateKeyUniqueIndex : Exception
    {
        public CannotInsertDuplicateKeyUniqueIndex(string message) : base(message) { }
    }

    public class ArithmeticOverflow : Exception
    {
        public ArithmeticOverflow(string message) : base(message) { }
    }

    public class StringOrBinaryDataWouldBeTruncated : Exception
    {
        public StringOrBinaryDataWouldBeTruncated(string message) : base(message) { }
    }

    public class OutOfStatus : Exception
    {
        public OutOfStatus(string message) : base(message) { }
    }
}

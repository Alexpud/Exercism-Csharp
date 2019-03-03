using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception();
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        return Char.IsDigit(input[0]) ? (int?)Int32.Parse(input) : null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        result = HandleErrorByReturningNullableType(input) ?? 0;
        return result == 0 ? false : true;
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        disposableObject.Dispose();
        throw new Exception();
    }
}

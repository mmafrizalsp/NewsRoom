namespace NewsRoom.Models;

public class MetaDataResult
{
    public int code { get; set; } = 200;
    public string message { get; set; } = "";
    public object result { get; set; } = new();
}

public static class MetaDataResponseResult
{
    public static MetaDataResult Ok(object result)
    {
        return new MetaDataResult()
        {
            code = 200,
            message = "Success",
            result = result
        };
    }

    public static MetaDataResult Error(object result)
    {
        return new MetaDataResult()
        {
            code = 500,
            message = "Error",
            result = result
        };
    }

    public static MetaDataResult Warning(object result)
    {
        return new MetaDataResult()
        {
            code = 501,
            message = "Warning",
            result = result
        };
    }
}
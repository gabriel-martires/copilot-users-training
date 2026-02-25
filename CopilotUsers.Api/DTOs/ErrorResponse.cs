namespace CopilotUsers.Api.DTOs;

public class ErrorResponse
{
    public List<ErrorDetail> Errors { get; set; } = new();
}

public class ErrorDetail
{
    public string Code { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}

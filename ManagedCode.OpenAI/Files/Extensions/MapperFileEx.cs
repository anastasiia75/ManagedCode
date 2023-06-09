using ManagedCode.OpenAI.API.File;

namespace ManagedCode.OpenAI.Files;

internal static class MapperFileEx
{
    public static IFileInfo ToFileInfo(this FileInfoDto dto)
    {
        return new FileInfo()
        {
            Bytes = dto.Bytes,
            CreatedAt = DateTimeOffset.FromUnixTimeSeconds(dto.CreatedAt).DateTime,
            Filename = dto.Filename,
            Id = dto.Id,
            Purpose = dto.Purpose
        };
    }
    
    public static IFileInfo[] ToFileInfoArray(this FilesInfoResponseDto dto)
    {
        return dto.Data
            .Select(e => e.ToFileInfo())
            .ToArray();
    }
    
    public static bool GetDeleteResult(this FileDeleteResponseDto dto)
    {
        return dto.Deleted;
    }
    
}
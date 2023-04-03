using ManagedCode.OpenAI.API.Moderations;
using ManagedCode.OpenAI.Moderations.Abstractions;
using ManagedCode.OpenAI.Moderations.Model;

namespace ManagedCode.OpenAI.Moderations.Exceptions;

public static class MapperModerationEx
{
    public static ICategory<TResult> ToCategory<TResult>(this CategoryDto<TResult> dto) where TResult : struct
    {
        return new Category<TResult>
        {
            Hate = dto.Hate,
            HateThreatening = dto.HateThreatening,
            SelfHarm = dto.SelfHarm,
            Sexual = dto.Sexual,
            SexualMinors = dto.SexualMinors,
            Violence = dto.Violence,
            ViolenceGraphic = dto.ViolenceGraphic
        };
    }

    private static IModeration ToModeration(this CategoryResultDto dto)
    {
        return new Moderation()
        {
            Categories = dto.Categories.ToCategory(),
            CateroryScores = dto.CategoryScores.ToCategory()
        };
    }
    
    
    public static IModeration ToModeration(this ModerationResponseDto dto)
    {
        return dto.Results.First().ToModeration();
    }

    public static IModeration[] ToModerations(this ModerationResponseDto dto)
    {
        return dto.Results.Select(e => e.ToModeration()).ToArray();
    }
        
    
}
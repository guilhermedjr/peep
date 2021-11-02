using System.Text.Json.Serialization;

namespace Peep.Wings.Domain.Dtos;

public class TwitterUserInfo
{
    public readonly string Name;
    public readonly string Description;
    public readonly string Username;
    [JsonPropertyName("profile_image_url")]
    public readonly string ProfileImageUrl;
}


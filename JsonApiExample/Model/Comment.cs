using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace JsonApiExample.Model
{

    [Resource]
    public class Comment : Identifiable<int>
    {
        [Attr]
        public string Content { get; set; }
        [Attr]
        public DateTime CreatedAt { get; set; }

        [HasOne]
        public Post Post { get; set; }
    }
}

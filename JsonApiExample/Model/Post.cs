using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace JsonApiExample.Model
{
    [Resource]
    public class Post : Identifiable<int>{

        [Attr]
        public string Title { get; set; }

        [Attr]
        public string Content { get; set; }

        [Attr]
        public DateTime CreatedAt { get; set; }

        [HasOne]
        public Category Category { get; set; }

        [HasMany]
        public List<Comment> Comments { get; set; }
    }
}

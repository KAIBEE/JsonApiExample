using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Serialization.Response;
using JsonApiExample.Model;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add JsonApiDotNetCore services.
builder.Services.AddSqlite<JsonApiDbContext>("Data Source=JsonApiExample4.db");
builder.Services.AddJsonApi<JsonApiDbContext>();

// metadata au niveau du post
builder.Services.AddResourceDefinition<PostDefinition>();

// metadata au niveau api
builder.Services.AddSingleton<IResponseMeta, CopyrightMeta>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add JsonApiDotNetCore middleware.
app.UseJsonApi();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
await CreateDatabaseAsync(app.Services);

app.Run();

static async Task CreateDatabaseAsync(IServiceProvider serviceProvider)
{
    await using AsyncServiceScope scope = serviceProvider.CreateAsyncScope();

    var dbContext = scope.ServiceProvider.GetRequiredService<JsonApiDbContext>();
    await dbContext.Database.EnsureCreatedAsync();

    if (!dbContext.Post.Any() || !dbContext.Category.Any())
    {
        var post = new Post
        {
            Title = "My first post",
            Content = "My first post content !",
            CreatedAt = DateTime.Now,
            Comments = new List<Comment>() { new Comment { Content = "Great post !", CreatedAt = DateTime.Now }, new Comment { Content = "Thx for posting this !", CreatedAt = DateTime.Now } }
        };
        var post2 = new Post
        {
            Title = "My second post",
            Content = "My second post content !",
            CreatedAt = DateTime.Now,
            Comments = new List<Comment>() { new Comment { Content = "Great second post !", CreatedAt = DateTime.Now }, new Comment { Content = "Thx for posting this again!", CreatedAt = DateTime.Now } }
        };
        var category = new Category
        {
            Title = "My first category",
            Description = "category description",
            CreatedAt = DateTime.Now,
            Posts = new List<Post>() { post, post2 }
        };
        post.Category = category;
        post2.Category = category;
        dbContext.Post.Add(post);
        dbContext.Post.Add(post2);
        dbContext.Category.Add(category);

        var post3 = new Post
        {
            Title = "My post 3",
            Content = "My post 3 content !",
            CreatedAt = DateTime.Now,
            Comments = new List<Comment>() { new Comment { Content = "Great post !", CreatedAt = DateTime.Now }, new Comment { Content = "Thx for posting this !", CreatedAt = DateTime.Now } }
        };
        var post4 = new Post
        {
            Title = "My post 4",
            Content = "My post 4 content !",
            CreatedAt = DateTime.Now,
            Comments = new List<Comment>() { new Comment { Content = "Great second post !", CreatedAt = DateTime.Now }, new Comment { Content = "Thx for posting this again!", CreatedAt = DateTime.Now } }
        };
        var post5 = new Post
        {
            Title = "My post 5",
            Content = "My post 5 content !",
            CreatedAt = DateTime.Now,
            Comments = new List<Comment>() { new Comment { Content = "Great second post !", CreatedAt = DateTime.Now }, new Comment { Content = "Thx for posting this again!", CreatedAt = DateTime.Now } }
        };
        var category2 = new Category
        {
            Title = "My 2nd category",
            Description = "category description",
            CreatedAt = DateTime.Now,
            Posts = new List<Post>() { post3, post4, post5 }
        };
        post3.Category = category2;
        post4.Category = category2;
        post5.Category = category2;
        dbContext.Post.Add(post3);
        dbContext.Post.Add(post4);
        dbContext.Post.Add(post5);
        dbContext.Category.Add(category2);
    }
    await dbContext.SaveChangesAsync();
}

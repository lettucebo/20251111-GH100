using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with In-Memory database
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseInMemoryDatabase("TodoDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}")
    .WithStaticAssets();

// Seed some sample data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TodoContext>();
    
    if (!context.TodoItems.Any())
    {
        context.TodoItems.AddRange(
            new TodoItem
            {
                Title = "完成專案文件",
                Description = "撰寫專案的技術文件和使用說明",
                IsCompleted = false,
                CreatedAt = DateTime.Now.AddDays(-2)
            },
            new TodoItem
            {
                Title = "Code Review",
                Description = "檢視團隊成員的程式碼並提供回饋",
                IsCompleted = false,
                CreatedAt = DateTime.Now.AddDays(-1)
            },
            new TodoItem
            {
                Title = "修復 Bug #123",
                Description = "解決登入頁面的驗證問題",
                IsCompleted = true,
                CreatedAt = DateTime.Now.AddDays(-3),
                CompletedAt = DateTime.Now.AddDays(-1)
            }
        );
        context.SaveChanges();
    }
}

app.Run();

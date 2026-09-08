var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseNpsgsql(Server=ep-crimson-surf-a5vn7wan-pooler.us-east-2.aws.neon.tech;DB=neondb;UID=neondb_owner;PWD=npg_p5IUBlhx7tnu;SslMode=require);
});

var app = builder.Build();

app.MapGet("/", ([FromServices]MyDbContext dbContext) =>
{
    var myFlower = new Flowersystem()
    {
        Title = "flowername",
        Id = "flowerId"
        Description = "isBigFlower"
    }
    dbContext.Flowersystem.add.myFlower;
    dbContext.SaveChanges();
    var objects = dbContext.Flowersystem.ToList();
    return objects;
    
} );

app.Run();

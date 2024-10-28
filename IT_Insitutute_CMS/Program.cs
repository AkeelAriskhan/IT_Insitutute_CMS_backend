
using IT_Insitutute_CMS.Database;
using IT_Insitutute_CMS.IRepositories;
using IT_Insitutute_CMS.Repositories;

namespace IT_Insitutute_CMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseWebRoot("wwwroot");


            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddSingleton<IAdminRepository>(provider => new AdminRepository(connectionString));
            builder.Services.AddSingleton<IStudentRepository>(provider => new StudentRepository(connectionString));
            builder.Services.AddSingleton<IPaymentRepository>(provider => new PaymentsRepository(connectionString));
            builder.Services.AddSingleton<IContactUsRepository>(provider => new ContactUsRepository(connectionString));
            builder.Services.AddSingleton<INotificationRepository>(provider => new NotificationRepository(connectionString));




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var initialize = new DatabaseInitializer(connectionString);
            initialize.Initialize();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

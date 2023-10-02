using AberturaEmpresas.DBService;
using AberturaEmpresas.EndPoints;
using AberturaEmpresas.EndPoints.Admin;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// **** TERMINAR DE CONFIGURAR ****
//builder.Services.AddDbContext<AppDBContext>(options =>
//options.UseMySql());

var app = builder.Build();

app.UseHttpsRedirection();

//app.MapMethods(Home.Template, Home.Methods, Home.Handler);
//app.MapMethods(CadastroRelacaoCnaeMunicipio.Template, CadastroRelacaoCnaeMunicipio.Methods, CadastroRelacaoCnaeMunicipio.Handler);
app.Run();

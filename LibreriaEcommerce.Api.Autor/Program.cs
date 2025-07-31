using LibreriaEcommerce.Api.Autor;

var app = Startup.InitApp(args);

app.MapGet("/", () => "Hola Mundo");

app.Run();

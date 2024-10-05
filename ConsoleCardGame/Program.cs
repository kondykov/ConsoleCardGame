using ConsoleCardGame.Services;
using ConsoleCardGame.UserInterface.Pages;

var initializer = Initializer.Initialize();

await initializer;

HomePage homePage = new();
while (true) homePage.View();
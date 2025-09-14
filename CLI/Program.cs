// See https://aka.ms/new-console-template for more information

using CLI.UI;
using InMemory;
using RepositoryContracts;

Console.WriteLine("Starting CLI app...");
IUser userRepository = new UserInMemory();
IComment commentRepository = new CommentInMemory();
IPost postRepository = new PostInMemory();

CliApp cliApp = new CliApp(userRepository,commentRepository,postRepository);
await cliApp.StartAsync();



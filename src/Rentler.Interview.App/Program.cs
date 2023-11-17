// See https://aka.ms/new-console-template for more information
using Rentler.Interview.Lib;
using static System.Net.WebRequestMethods;

Console.WriteLine("Hello, World!");

var baseUrl = "https://localhost:7263";

var client = new FoodClient(baseUrl);

var result = await client.getAllFoods(1, 6);
var pagingMetadata = result.Item1;
var foods = result.Item2;

Console.WriteLine($"Paging MetaData");
Console.WriteLine($"Current CurrentPage: {pagingMetadata.CurrentPage}");
Console.WriteLine($"Current NextPage: {pagingMetadata.NextPage}");
Console.WriteLine($"Current PreviousPage: {pagingMetadata.PreviousPage}");
Console.WriteLine($"Current TotalPages: {pagingMetadata.TotalPages}");
Console.WriteLine($"Current PageSize: {pagingMetadata.PageSize}");
Console.WriteLine($"Current TotalCount: {pagingMetadata.TotalCount}");

Console.WriteLine();

foreach (var food in foods)
{
    Console.WriteLine($"Id: {food.FoodId}");
    Console.WriteLine($"Brand: {food.Brand}");
    Console.WriteLine($"Description: {food.Description}");
    Console.WriteLine($"Calories: {food.Calories}");
    Console.WriteLine();
}

Console.WriteLine("Now with coffee as a search term");

result = await client.getAllFoods(1, 6, "coffee");
pagingMetadata = result.Item1;
foods = result.Item2;

Console.WriteLine($"Paging MetaData");
Console.WriteLine($"Current CurrentPage: {pagingMetadata.CurrentPage}");
Console.WriteLine($"Current NextPage: {pagingMetadata.NextPage}");
Console.WriteLine($"Current PreviousPage: {pagingMetadata.PreviousPage}");
Console.WriteLine($"Current TotalPages: {pagingMetadata.TotalPages}");
Console.WriteLine($"Current PageSize: {pagingMetadata.PageSize}");
Console.WriteLine($"Current TotalCount: {pagingMetadata.TotalCount}");

Console.WriteLine();

foreach (var food in foods)
{
    Console.WriteLine($"Id: {food.FoodId}");
    Console.WriteLine($"Brand: {food.Brand}");
    Console.WriteLine($"Description: {food.Description}");
    Console.WriteLine($"Calories: {food.Calories}");
    Console.WriteLine();
}

Console.ReadLine();
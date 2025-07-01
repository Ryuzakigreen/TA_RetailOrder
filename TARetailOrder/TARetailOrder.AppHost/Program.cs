
var builder = DistributedApplication.CreateBuilder(args);

//var db = builder.AddPostgres("db").WithPgAdmin();
//var retailOrderDb = db.AddDatabase("RetailOrderDB");

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.TARetailOrder_ApiService>("RetailOrderApiService")
    //.WithReference(retailOrderDb)
    .WithReference(cache);

// Blazor Frontend
//builder.AddProject<Projects.TARetailOrder_Web>("webfrontend")
//    .WithExternalHttpEndpoints()
//    .WithReference(cache)
//    .WaitFor(cache)
//    .WithReference(apiService)
//    .WaitFor(apiService);

builder.Build().Run();

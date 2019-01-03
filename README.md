# MemeShare
Example Repository for Xamarin.Forms and SignalR use

## Projects

- MemeShare

  - Xamarin.Forms shared .netStandard library

- MemeShare.iOS

  - Xamarin.Forms iOS platform project
  
- MemeShare.Android

  - Xamarin.Forms Android platform project
  
- MemeShare.Web

  - .net standard Web API project
  - To run for android, use `dotnet run --project MemeShare.Web --urls http:0.0.0.0:5000` and 
  update all domains from `localhost` to your IP address
  
- MemeShare.WebContracts

  - .net standard library
  - Contains all models and services for .net projects to communicate with MemeShare.Web instances

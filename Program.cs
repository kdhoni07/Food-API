
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using TokenApi.services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Authentication;

WebHost.CreateDefaultBuilder().
ConfigureServices(s=>
{
    IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    s.AddSingleton<Login>();
    s.AddSingleton<Registration>();
    s.AddSingleton<ItemOnSearch>();
    s.AddSingleton<ItemsOnDashboard>();
     s.AddSingleton<AddFoodToCart>();
     s.AddSingleton<ShowOrder>();
     s.AddSingleton<UpdateDetails>();
 s.AddSingleton<UpdatePassword>();
 s.AddSingleton<DeleteAccount>();
s.AddSingleton<UserDetails>();
s.AddSingleton<DisplayOnCart>();
s.AddSingleton<OrderHistory>();
s.AddSingleton<FoodOnFavourite>();
s.AddSingleton<Favourite>();
s.AddSingleton<FavouriteRemove>();
s.AddSingleton<OrderDelete>();
 s.AddSingleton<ForgetPassword>();
s.AddAuthorization();
s.AddControllers();
s.AddCors();
s.AddAuthentication("SourceJWT").AddScheme<SourceJwtAuthenticationSchemeOptions, SourceJwtAuthenticationHandler>("SourceJWT", options =>
    {
        options.SecretKey = appsettings["jwt_config:Key"].ToString();
        options.ValidIssuer = appsettings["jwt_config:Issuer"].ToString();
        options.ValidAudience = appsettings["jwt_config:Audience"].ToString();
        options.Subject = appsettings["jwt_config:Subject"].ToString();
    });

}).Configure(app=>
{
// app.UseAuthentication();
// app.UseAuthorization();
 app.UseCors(options =>
         options.WithOrigins("https://localhost:5002", "http://localhost:5001")
        
         .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.UseEndpoints(e=>
{
           var login=  e.ServiceProvider.GetRequiredService<Login>();
            var register = e.ServiceProvider.GetRequiredService<Registration>();
            var itemsOnDashboard= e.ServiceProvider.GetRequiredService<ItemsOnDashboard>();
            var itemOnSearch=e.ServiceProvider.GetRequiredService<ItemOnSearch>();
             var addfoodoncart= e.ServiceProvider.GetRequiredService<AddFoodToCart>();
               var showorder= e.ServiceProvider.GetRequiredService<ShowOrder>();
               var updatepassword =e.ServiceProvider.GetRequiredService<UpdatePassword>();
                var getuserdetails =e.ServiceProvider.GetRequiredService<UserDetails>();
               var updateuserdetails =e.ServiceProvider.GetRequiredService<UpdateDetails>();
                var userdelete =e.ServiceProvider.GetRequiredService<DeleteAccount>();
                 var orderimage =e.ServiceProvider.GetRequiredService<DisplayOnCart>();
                  var orderHistory  =e.ServiceProvider.GetRequiredService<OrderHistory>();
                  var favouriteFood =e.ServiceProvider.GetRequiredService<Favourite>();
                    var favouriteremove =e.ServiceProvider.GetRequiredService<FavouriteRemove>();
var foodonfavourite  =e.ServiceProvider.GetRequiredService<FoodOnFavourite>();
var orderDelete  =e.ServiceProvider.GetRequiredService<OrderDelete>();
var forgetpassword =e.ServiceProvider.GetRequiredService<ForgetPassword>();

          
 e.MapPost("login",
        [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await login.LoginData(rData));

         });
         e.MapPost("registration",
       [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await register.Register(rData));

         });
          e.MapPost("itemondashboard",
       [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await itemsOnDashboard.GetImage(rData));
              else if (rData.eventID == "1002")
                         await http.Response.WriteAsJsonAsync(await itemsOnDashboard.GetPizza(rData));
               else if (rData.eventID == "1003")
                         await http.Response.WriteAsJsonAsync(await itemsOnDashboard.GetPasta(rData));

              else if (rData.eventID == "1004")
                         await http.Response.WriteAsJsonAsync(await itemsOnDashboard.GetSalad(rData));

              else if (rData.eventID == "1005")
                         await http.Response.WriteAsJsonAsync(await itemsOnDashboard.GetBurger(rData));


         });
         //item on search
       e.MapPost("itemonsearch",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await itemOnSearch.GetImageOnSearch(rData));

         });
         e.MapPost("addtocart",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await addfoodoncart.AddItemToCart(rData));

         });
            e.MapPost("displayOnCart",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await orderimage.ShowItemOnOrder(rData));
                          else  if (rData.eventID == "1002")
                         await http.Response.WriteAsJsonAsync(await orderimage.OrderPizza(rData));
                          else  if (rData.eventID == "1003")
                         await http.Response.WriteAsJsonAsync(await orderimage.OrderPasta(rData));
                          else  if (rData.eventID == "1004")
                         await http.Response.WriteAsJsonAsync(await orderimage.OrderSalad(rData));
                          else  if (rData.eventID == "1005")
                         await http.Response.WriteAsJsonAsync(await orderimage.OrderBurger(rData));
                        
                        
         });
        
           e.MapPost("orderfood",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await showorder.DisplayOrder(rData));

         });
           e.MapPost("orderhistory",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await orderHistory.PlaceOrder(rData));

         });
           e.MapPost("orderdelete",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await orderDelete.DeleteOrder(rData));

         });
          e.MapPost("updatepassword",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await updatepassword.PasswordUpdate(rData));

         });
        
             e.MapPost("forgetpassword",
      [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await forgetpassword.PasswordForget(rData));

         });
          e.MapPost("getuserdetails",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await getuserdetails.GetDataById(rData));

         });
      e.MapPost("updateuserdetails",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await updateuserdetails.UpdateAll(rData));

         });
    e.MapPost("deleteuser",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await userdelete.DeleteDocument(rData));

         });
         e.MapPost("favouritefood",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await favouriteFood.AddToFavourite(rData));
                           else  if (rData.eventID == "1002")
                         await http.Response.WriteAsJsonAsync(await favouriteFood.AddToFavouritePizza(rData));
                          else  if (rData.eventID == "1003")
                         await http.Response.WriteAsJsonAsync(await favouriteFood.AddToFavouritePasta(rData));
                          else  if (rData.eventID == "1004")
                         await http.Response.WriteAsJsonAsync(await favouriteFood.AddToFavouriteSalad(rData));
                          else  if (rData.eventID == "1005")
                         await http.Response.WriteAsJsonAsync(await favouriteFood.AddToFavouriteBurger(rData));

         });
           e.MapPost("foodtoshowonfavourite",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await foodonfavourite.ShowOnFavourite(rData));

         });
          e.MapPost("removefromfavourite",
      [Authorize(AuthenticationSchemes ="SourceJWT")] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001")
                         await http.Response.WriteAsJsonAsync(await favouriteremove.RemoveFavourite(rData));

         });
    

    

});
}).Build().Run();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
public record requestData
{
    [Required]
    public string eventID { get; set; }
    [Required]
    public IDictionary<string, object> addInfo { get; set; }

   
}

public record responseData
{
    public responseData()
    {
        eventID = "";
        rStatus = 0;
        rData = new Dictionary<string, object>();
    }
    [Required]
    public int rStatus { get; set; } = 0;
    public string eventID { get; set; }
    public IDictionary<string, object> addInfo { get; set; }
    public IDictionary<string, object> rData { get; set; }
}

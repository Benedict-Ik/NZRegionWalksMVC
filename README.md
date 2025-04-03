Here is what we did in this branch:

- Here we consumed the `Regions` endpoint.
- Started off commenting out all `[Authorize]` attributes to ensure access to specific methods.
- Added a new controller called `RegionsController`.
- Created an empty view with the name - `Index.cshtml` embedded in a `Regions` folder which in turn is embedded in the `Views` folder.

Important Note
---
In ASP.NET Core, HttpClient is a class that enables sending HTTP requests and receiving HTTP 
responses from web servers, making it essential for consuming APIs. It allows you to interact
with web APIs, services, and resources, handling requests and responses, including parsing 
data and errors. Its importance lies in providing a flexible and customizable way to 
consume APIs, enabling your application to communicate with external services, 
retrieve data, and integrate with third-party systems, ultimately enhancing 
its functionality and capabilities.

___

- To use the HttpClient, we have to inject it into our `Program.cs` file just before the `builder.build()` method.
```csharp
builder.Services.AddHttpClient();
```

- We then inject the `HttpClient` into our `RegionsController` constructor.
```csharp
private readonly IHttpClientFactory _httpClientFactory;

public RegionsController(IHttpClientFactory httpClientFactory)
{
	this._httpClientFactory = httpClientFactory;
}
```

- To use it in our project, we can add the below line:
```csharp
var client = _httpClientFactory.CreateClient();
```

Explanation of RegionsController.cs
---
**Class declaration and inheritance**
```csharp
public class RegionsController : Controller
```

- This declares a new public class named RegionsController.
- The class inherits from the Controller class, which is a base class for controllers in ASP.NET Core.

**Private field declaration**
```csharp
private readonly IHttpClientFactory _httpClientFactory;
```

- This declares a private field named _httpClientFactory of type IHttpClientFactory.
- The readonly keyword means that the field can only be assigned a value once, in the constructor.

**Constructor**
```csharp
public RegionsController(IHttpClientFactory httpClientFactory)
{
    this._httpClientFactory = httpClientFactory;
}
```

- This is the constructor for the RegionsController class.
- The constructor takes an instance of IHttpClientFactory as a parameter.
- The constructor assigns the httpClientFactory parameter to the private field _httpClientFactory.

**Action method declaration**
```csharp
public async Task<IActionResult> Index()
```

- This declares a new public action method named Index.
- The method returns a Task<IActionResult>, which means it's an asynchronous method that returns an IActionResult.

**Initialize response list**
```csharp
List<RegionDTO> response = new List<RegionDTO>();
```

- This initializes a new empty list of RegionDTO objects.

**Try-catch block**
```csharp
try
{
    // code here
}
catch (Exception ex)
{
    // error handling code here
}
```

- This is a try-catch block that catches any exceptions that occur in the code inside the try block.

**Create HTTP client instance**
```csharp
var client = _httpClientFactory.CreateClient();
```

- This creates a new instance of HttpClient using the _httpClientFactory field.

**Send GET request**
```csharp
var httpResponseMessage = await client.GetAsync("https://localhost:7148/api/regions");
```

- This sends a GET request to the specified URL using the HttpClient instance.
- The await keyword means that the method waits for the response before continuing.

**Ensure successful status code**
```csharp
httpResponseMessage.EnsureSuccessStatusCode();
```

- This checks if the response status code is successful (200-299).
- If the status code is not successful, it throws an exception.

**Extract data from response**
```csharp
/* Extract the data from the response */
// var bodyResponse = await httpResponseMessage.Content.ReadAsStringAsync();
```

- This code is commented out, but it would read the response content as a string.

**Deserialize response content to objects**
```csharp
response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDTO>>());
```

- This reads the response content and deserializes it into a list of RegionDTO objects using the ReadFromJsonAsync method.

**Return view with response data**
```csharp
return View(response);
```

- This returns a view with the response data.

**Catch block**
```csharp
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw; 
}
```
- This catches any exceptions that occur in the try block.
- It writes the exception to the console.
- It rethrows the exception using the throw keyword.

<br><br>



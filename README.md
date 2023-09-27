# ACE API

This is a demo project for a job interview with ACE digital solutions. The project is built with C# and ASP.NET Core and is hosted on Azure App Service (Linux).

## Demo

You can access the demo at the following URLs:

- Primary: [https://ace-api.cloud.tcraft.ch/\*](https://ace-api.cloud.tcraft.ch/)
- Fallback: [https://ace-api20230927212456.azurewebsites.net/\*](https://ace-api.cloud.tcraft.ch/)

_Please replace \* with the specific API endpoint you want to access._

## Endpoints

The API provides the following endpoints:

1. GetTemp

   - Endpoint: [/api/temp](https://ace-api.cloud.tcraft.ch/api/temp)
   - Method: GET
   - Query Parameters:
     - celsius: The temperature in Celsius to convert to Kelvin.
     - kelvin: The temperature in Kelvin to convert to Celsius.
   - Description: Converts a temperature from Celsius to Kelvin or from Kelvin to Celsius. You should specify either celsius or kelvin, but not both.
   - Examples:
     - To convert 25 degrees Celsius to Kelvin, you would use [/api/temp?celsius=25](https://ace-api.cloud.tcraft.ch/api/temp?celsius=25).
     - To convert 298.15 Kelvin to Celsius, you would use [/api/temp?kelvin=298.15](https://ace-api.cloud.tcraft.ch/api/temp?kelvin=298.15).

2. GetPrimeNumbers

   - Endpoint: [/api/prime](https://ace-api.cloud.tcraft.ch/api/prime)
   - Method: GET
   - Query Parameters:
     - limit: The upper limit for generating prime numbers.
   - Description: Generates a list of prime numbers up to a specified limit.
   - Example: To get all prime numbers up to 100, you would use [/api/prime?limit=100](https://ace-api.cloud.tcraft.ch/api/prime?limit=100)

3. GetFibonacciNumber
   - Endpoint: [/api/number](https://ace-api.cloud.tcraft.ch/api/number)
   - Method: GET
   - Query Parameters:
     - n: The position of the Fibonacci number to generate.
   - Description: Generates the nth Fibonacci number.
   - Example: To get the 10th Fibonacci number, you would use [/api/number?n=10](https://ace-api.cloud.tcraft.ch/api/number?n=10)

_Please refer to the [Postman Collection](src\Ace.Api\ace_api.postman_collection.json) for more details on how to use these endpoints._

## Testing

The project includes unit tests, which are written using the xUnit framework. The tests are designed to ensure that the API behaves as expected under various conditions. They cover both positive cases (where the API should return a successful response) and negative cases (where the API should handle errors gracefully).

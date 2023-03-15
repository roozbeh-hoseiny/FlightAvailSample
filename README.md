# What is FlightAvailSample and what do we learn by FlightAvailSample?


This is a sample project to retrieve available flights from multiple suppliers through API calls. It includes a service that uses a supplier factory to obtain the appropriate supplier to call its API.

Each supplier is an adapter that makes an API call to retrieve data, and then maps the response to the desired format.


- Factory Pattern
- Adapter Pattern
- Using multiple IHttpClient with different options
- IOptions Pattern


this 

# What is "FlightAvailSample", and what can we learn from it?


This is a sample project to retrieve available flights from multiple suppliers through API calls. It includes a service that uses a supplier factory to obtain the appropriate supplier to call its API.

Each supplier is an adapter that makes an API call to retrieve data, and then maps the response to the desired format.

# CarManagement

**CarManagement** is a web application designed to manage car rentals, including functionalities to view, add, update, and delete rental records.

## Table of Contents
- [Technologies Used](#technologies-used)
- [API Endpoints](#api-endpoints)
  - [Sample Request/Response for `/rentals`](#sample-requestresponse-for-rentals)
- [Running the Application](#running-the-application)

## Technologies Used
- **ASP.NET Core**: The primary framework for building the web application.
- **Entity Framework Core**: Used for data access and ORM (Object-Relational Mapping).
- **Mapperly**: A high-performance .NET mapper utilized for object-to-object mapping within the application.

## API Endpoints

The application exposes several API endpoints to manage car rentals. Below is the sample request and response for the `/rentals` endpoint.

### Sample Request/Response for `/rentals`

**Endpoint**: `GET /rentals`  
**Description**: Retrieves a list of all car rentals.

#### Sample Request:

```http
GET /rentals HTTP/1.1
Host: localhost:5000
Accept: application/json
```

Sample Response:
```json
[
  {
    "id": 1,
    "carInfo": "Toyota Camry 2022",
    "renterName": "John Doe",
    "rentalDate": "2025-04-01T10:00:00",
    "returnDate": "2025-04-10T10:00:00"
  },
  {
    "id": 2,
    "carInfo": "Honda Accord 2023",
    "renterName": "Jane Smith",
    "rentalDate": "2025-04-05T12:00:00",
    "returnDate": "2025-04-15T12:00:00"
  }
]
```
> **Note**: The carInfo field is a concatenation of the car's make, model, and year, formatted as "Make Model Year".

### Running the Application
To run the CarManagement application locally, follow these steps:

Clone the Repository:

```
git clone https://github.com/OneWay2Go/CarManagement.git
```

Navigate to the Project Directory:

```
cd CarManagement
```

Restore Dependencies:

Ensure you have the .NET SDK installed. Then, restore the necessary packages:

```
dotnet restore
```

Apply Migrations and Update the Database:

The application uses Entity Framework Core for data access. Apply any pending migrations and update the database:

```
dotnet ef database update
```

#### Run the Application:

Start the application:

```
dotnet run
```

Access the Application:

Once running, the application will be accessible at http://localhost:5000.

You can interact with the API endpoints using tools like Postman or cURL.
> Note: Ensure that any required environment variables or configuration settings are properly set before running the application. Refer to the project's documentation or configuration files for more details.

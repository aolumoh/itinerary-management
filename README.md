
# Itinerary Management System API

## Overview

The Itinerary Management System API is a centralized platform designed to help users manage their travel itineraries, including flights, accommodations (stays), and activities. The API provides CRUD operations and allows users to easily add, view, update, and delete their travel plans in one place.

## Features

- **Itinerary Management**: Create, view, update, and delete itineraries.
- **Flight Management**: Add flights to itineraries by specifying the itinerary name.
- **Stay Management**: Add accommodations to itineraries by specifying the itinerary name.
- **Activity Management**: Add activities to itineraries by specifying the itinerary name.
- **Validation**: Ensures unique itinerary names to avoid duplicates.

## Setup Instructions

### Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or another compatible database)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (`dotnet-ef`)
- [Swagger](https://swagger.io/) (for API documentation and testing, integrated into the project)

### Step 1: Clone the Repository

```bash
git clone https://github.com/aolumoh/itinerary-management.git
cd itinerary-management
```

### Step 2: Configure the Database

Update the connection string in `appsettings.json` with your SQL Server details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=ItineraryDatabase;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
  }
}
```

Replace `YOUR_SERVER_NAME`, `YOUR_USERNAME`, and `YOUR_PASSWORD` with your actual SQL Server credentials.

### Step 3: Apply Migrations and Create the Database

Use the following commands to apply migrations and create the database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

These commands will set up the database schema based on the models defined in the project.

### Step 4: Run the Application

Run the application using the command:

```bash
dotnet run
```

The API will be available at `http://localhost:5000` (or the specified port).

### Step 5: Access the API Documentation

Navigate to `http://localhost:5000/swagger` in your browser to access the Swagger UI. This interface allows you to interact with and test the API endpoints.

## Usage Instructions

### 1. Creating an Itinerary

- **Endpoint**: `POST /api/itinerary`
- **Description**: Create an itinerary with a unique name before adding any flights, stays, or activities.
- **Request Body**:
  
  ```json
  {
    "name": "My Summer Trip",
    "startDate": "2024-07-01T00:00:00",
    "endDate": "2024-07-10T00:00:00"
  }
  ```

### 2. Adding Flights to an Itinerary

- **Endpoint**: `POST /api/flight`
- **Description**: Add flights to an existing itinerary by specifying the itinerary name.
- **Request Body**:

  ```json
  {
    "airline": "Delta Airlines",
    "flightNumber": "DL123",
    "departureDate": "2024-07-01T08:00:00",
    "arrivalDate": "2024-07-01T12:00:00",
    "itineraryName": "My Summer Trip"
  }
  ```

### 3. Adding Stays to an Itinerary

- **Endpoint**: `POST /api/stay`
- **Description**: Add accommodations to an existing itinerary by specifying the itinerary name.
- **Request Body**:

  ```json
  {
    "accommodationName": "Hilton Hotel",
    "checkInDate": "2024-07-01T15:00:00",
    "checkOutDate": "2024-07-05T11:00:00",
    "itineraryName": "My Summer Trip"
  }
  ```

### 4. Adding Activities to an Itinerary

- **Endpoint**: `POST /api/activity`
- **Description**: Add activities to an existing itinerary by specifying the itinerary name.
- **Request Body**:

  ```json
  {
    "activityName": "City Tour",
    "description": "A guided city tour with stops at major landmarks.",
    "location": "New York City",
    "startTime": "2024-07-02T09:00:00",
    "endTime": "2024-07-02T12:00:00",
    "itineraryName": "My Summer Trip"
  }
  ```

### Important Note
- **Itinerary Dependency**: Before adding a flight, stay, or activity, ensure an itinerary with the specified name exists. Itineraries must be created first to avoid errors related to missing or incorrect itinerary references.

### 5. Viewing Itinerary Details

- **Endpoint**: `GET /api/itinerary/{id}`
- **Description**: Retrieve the details of a specific itinerary, including its associated flights, stays, and activities.
  
### 6. Updating an Itinerary

- **Endpoint**: `POST /api/itinerary/{id}`
- **Description**: Update an existing itinerary by ID. Ensure the ID in the URL matches the ID in the request body.

### 7. Deleting an Itinerary

- **Endpoint**: `DELETE /api/itinerary/{id}`
- **Description**: Delete an itinerary by its ID, which also removes associated flights, stays, and activities due to cascade delete behavior.

## Error Handling

- The API provides meaningful error messages for validation failures, duplicate entries, and missing data scenarios. Ensure you handle these errors in your client application to improve user experience.

## Future Enhancements

- **User Authentication**: Adding user accounts for personalized itineraries.
- **Collaborative Itineraries**: Enabling shared itineraries among multiple users.
- **Live Updates**: Integrate with external services for live flight updates and activity recommendations.

## Contributing

Feel free to fork this project, submit issues, and create pull requests. Contributions are welcome!

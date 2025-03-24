Ihr könnt mich (Stefan Wiesinger / Product Owner) unter stefanwiesinger2005@gmail.com erreichen.

# TdoT-Backend (Tag der offenen Tür)

This is the backend application for the "Tag der offenen Tür" (Open House Day) system for HTL Grieskirchen. The system manages registrations, activities, and navigation for school trial days.

## Getting Started

### Clone Repository
```
git clone --recurse-submodules https://github.com/HTL-Grieskirchen-Schueler/TdoT-Backend.git
```

### Update Submodules
```
git submodule init 
git submodule update
```

### Prerequisites
- .NET 8.0 SDK
- Node.js/pnpm (for the admin panel)

### Running the Application
1. Navigate to the project directory:
   ```
   cd TdoT-Backend
   ```
2. Restore dependencies:
   ```
   dotnet restore
   ```
3. Build and run the application:
   ```
   dotnet run
   ```
4. Access Swagger UI at: http://localhost:5000/swagger

## Project Structure

### Core Components
- **Web API**: ASP.NET Core backend
- **Admin Panel**: Angular-based frontend (included as git submodule)

### Key Directories
- `/Data/`: Contains JSON configuration files and static content
  - `/html/`: Static web files (will get replaced by TdoT-Admin-Panel on build)
  - `/text/`: Text templates
  - `/floorPlans/`: SVG floor plans (0.svg and 1.svg)
- `/Services/`: Business logic services
- `/Controller/`: API endpoints
- `/Middleware/`: Authentication middleware
- `/Dtos/`: Data transfer objects

## Data Files

The system uses several JSON files in the Data directory:
- `activities.json`: List of activities during the trial day
- `nodes.json`: Navigation nodes for wayfinding
- `registrations.json`: Student registrations
- `trialdays.json`: Available trial days with capacity limits
- `placeholder.json`: Text template placeholders
- `text/registration.json`: Registration text content
- `text/SchnupperTagAnmeldung.txt`: Trial day information text

## Authentication

Admin endpoints are protected using a simple password-based authentication scheme. The password should be provided as a SHA-256 hash in the request header named "password".

## API Endpoints

### Public Endpoints
- `GET /navigation/floorsvg?floor={0|1}`: Retrieve floor plan SVG
- `GET /navigation/nodes`: Get navigation nodes
- `GET /navigation/activities`: Get activity information
- `GET /text/info`: Get trial day information text
- `GET /text/registration`: Get registration text
- `GET /trialdays`: Get available trial days
- `POST /trialdays/registration`: Submit a new registration

### Admin Endpoints (Requires Authentication)
- `GET /files`: List all editable files
- `GET /files?fileName={path}`: Get file content
- `POST /files`: Upload file content
- `GET /placeholder`: Get text placeholders
- `PUT /placeholder`: Update text placeholders
- `PUT /activities`: Update activities
- `GET /rooms`: Get distinct room names

## Development

### Adding New Features
1. Add DTOs to define data structures in the Dtos namespace
2. Create or update services in the Services namespace 
3. Add controller endpoints in the Controller namespace
4. Update the necessary JSON data files

### Build Process
The build process automatically builds the Angular admin panel if it exists and copies the output to the Data/html directory.

## Architecture

The application follows a layered architecture:
1. **Controller Layer**: Handles HTTP requests and responses
2. **Service Layer**: Contains business logic and data operations
3. **Data Layer**: JSON files stored in the Data directory

## Troubleshooting

- If files are not found, ensure the Data directory and its subdirectories are copied to the output directory
- Authentication issues may occur if the password hash is incorrect or missing
- For UI issues, rebuild the Admin Panel using the build target in the project file

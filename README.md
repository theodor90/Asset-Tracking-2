# Asset-Tracking-2

Project Structure

Data/ - Contains the Entity Framework Core DbContext.
Models/ - Contains the asset models.
Services/ - Contains the services for adding, viewing, updating, and deleting assets.
Program.cs - Main entry point of the application.


Code Structure

Program.cs

The main entry point of the application. It displays a menu and calls the appropriate service based on user input.

AddAssetService.cs

Contains the logic for adding a new asset. It prompts the user for asset details and saves the asset to the database.

SortAndDisplayAssetsService.cs

Contains the logic for displaying a sorted list of assets. It sorts the assets by purchase date and displays them in the console.

UpdateAssetService.cs

Contains the logic for updating an existing asset. It prompts the user for the asset type and ID, retrieves the asset, and allows the user to update its details.

DeleteAssetService.cs

Contains the logic for deleting an existing asset. It prompts the user for the asset type and ID and deletes the asset from the database.

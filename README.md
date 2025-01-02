# Library Management System

A comprehensive system designed to manage library resources, including books, patrons, and transactions, facilitating efficient library operations.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Features

- Manage books: Add, update, delete, and search for books.
- Patron management: Register and manage library patrons.
- Transaction handling: Issue and return books.
- Overdue tracking: Monitor and manage overdue items.
- Reporting: Generate reports on library usage and inventory.

## Technologies Used

- **C#**
- **HTML**
- **.NET Framework**
- **SQL Server** (for database management)

## Getting Started

### Prerequisites

- **.NET Framework**: Ensure that the .NET Framework is installed on your machine.
- **SQL Server**: Set up SQL Server for database management.

### Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/0Maxbon0/LibraryManagement-DEPI.git
   cd LibraryManagement-DEPI
   ```

2. **Set up the database**:

   - Create a new database in SQL Server.
   - Execute the provided SQL scripts in the `DatabaseScripts` directory to set up the necessary tables and seed data.

3. **Configure the application**:

   - Open the solution file `Library.sln` in Visual Studio.
   - Update the database connection string in the `appsettings.json` file to point to your SQL Server instance.

4. **Build and run the application**:

   - Build the solution in Visual Studio to restore dependencies.
   - Run the application to launch the Library Management System.

## Usage

- **Admin Panel**: Access the admin panel to manage books, patrons, and transactions.
- **Search Functionality**: Utilize the search feature to find books by title, author, or ISBN.
- **Issue/Return Books**: Process book issuances and returns through the transactions module.

## Contributing

Contributions are welcome! Please follow these steps:

1. **Fork the repository**.
2. **Create a new branch**:

   ```bash
   git checkout -b feature/YourFeatureName
   ```

3. **Commit your changes**:

   ```bash
   git commit -m 'Add some feature'
   ```

4. **Push to the branch**:

   ```bash
   git push origin feature/YourFeatureName
   ```

5. **Open a pull request**.


## Contact

- **Name**: Maxim Mamdouh Salib
- **Email**: bonasalib@gmail.com
- **GitHub**: [0Maxbon0](https://github.com/0Maxbon0)

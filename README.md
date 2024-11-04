# Driving and Vehicles Licenses Development Web-Based

## Overview
a .NET Desktop Application that structured with a N-tier Architecture, seamlessly integrated with a Microsoft SQL Server Database. It utilizes the capabilities of .NET Windows Form technology , written in C# programming language and follows the principles of Object-Oriented Programming (OOP).

## Key Features
- **Login Logs**: Records login activities for users.
- **License Classes**: Easily manage different license classes, allowing applicants to apply for specific categories such as Ordinary driving license, Small motorcycle, Commerical and etc.
- **Testing Procedures**: Schedule and administer three essential tests - vision test, written test, and street test - ensuring applicants meet the necessary criteria for license issuance.
- **User/Drivers Database**: Maintain a centralized database of users and drivers including details of drivers and individuals applying for various services.

## License Applications:
- **First-Time Application**: Streamlined process for applicants seeking their initial driving license.
- **Renewal Application**: Simplified renewal process for existing license holders.
- **Replacement Application**: Efficient handling of requests for replacing damaged or lost licenses.
- **Retake Tests Application**: Enable applicants to reapply for tests in case of previous failures.
- **International License Application**: Facilitate the application process for international driving licenses.
- **Release Detained License Application**: Users can request  release of their detained license, subject to the payment of fines.

## Workflow Overview
- **Application Submission**: Users can submit applications for different services through the system, specifying the type of service they require.
- **Test Scheduling**: Schedule vision, written, and street tests for applicants based on their license class and requirements.
- **Test Evaluation**: Efficiently evaluate and record the results of each test, determining whether the applicant has successfully passed or needs further action.
- **License Issuance**: Upon successful completion of all tests, the system give users access to the process of issuing the license.
- **Detention Feature**: Users have the ability to detain the diver license, initiating a process for payment of fines.
- **Release Application**: To lift the detention, applicants apply for a release detained license application, paying the required fines.
- **License Reactivation**: Upon successful payment, the system activates the license, making it operational again.
- **Database Maintenance**: Continuously update and maintain databases of People, Users, Drivers, Detained licenes, License classes, and Tests results for accurate record-keeping.

## Architecture Overview
- **Data Laye**r: Handles all database interactions, including CRUD operations for various entities. It is responsible for the communication between the application and the database.
- **Business Layer**: Contains the core business logic, ensuring that all processes adhere to the business rules and application workflow.
- **API Layer**: Exposes endpoints to interact with the application functionalities, facilitating communication between the front-end and back-end.
- **DTO Layer**: Structures data for efficient transmission between the API and the client, ensuring that data is appropriately formatted and secure.

## Front-End Development
The front-end layer is currently under development and will be integrated to provide a complete user interface for interacting with the application.

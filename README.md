# Driving and Vehicles Licenses Development Web-Based

## Overview
 an Angular and .NET Application structured with an N-tier Architecture, seamlessly integrated with a Microsoft SQL Server Database. The application utilizes the capabilities of Angular for the front-end and .NET for the back-end, written in C# programming language. It adheres to the principles of Object-Oriented Programming (OOP) and provides a dynamic and user-friendly interface powered by Angular while ensuring robust data management and processing through the .NET backend.

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
- The front end of the application is being developed using Angular and is integrated within the same repository.
- It aims to provide a user-friendly interface that seamlessly interacts with the back-end APIs. 
- The design follows a minimalist approach and ensures consistency with the application's overall functionality. 
- The front-end includes essential components such as a homepage, login, dashboard, and various sections for license management.

## Screenshots

![landing](https://github.com/user-attachments/assets/2e6626e9-3470-46c4-965a-b8e2c3333853)
![login](https://github.com/user-attachments/assets/560ef1c4-50d7-42e1-9eb8-50e5d06e9f74)
![process](https://github.com/user-attachments/assets/5e19625c-1e5f-4bc6-b891-8c76c9486594)
![whoweare](https://github.com/user-attachments/assets/0de4f61e-5c8f-4977-b7f1-be70a4bb48ef)
![contact](https://github.com/user-attachments/assets/6d343bc8-23e1-4ace-a7ca-62825184e603)
![dashboard](https://github.com/user-attachments/assets/e125b241-7d70-4397-bb83-79a5081d076c)
![appointments](https://github.com/user-attachments/assets/8eb394d6-15c7-4751-99b9-d85a6b70c4aa)
![applications](https://github.com/user-attachments/assets/0a8fe7b6-3896-44e6-8c65-6027f91dbf10)
![adding-new-application](https://github.com/user-attachments/assets/f48d2020-b8f4-4e95-b44e-cebc9f08b624)
![history](https://github.com/user-attachments/assets/a2919c68-42e2-4b45-aaef-4c5103b7fd3d)
![notification](https://github.com/user-attachments/assets/bc31e29b-3703-4123-84d7-4a772cd4ac1c)



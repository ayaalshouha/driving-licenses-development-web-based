# DVLD - Driving and Vehicles Licenses Development
a .NET Desktop Application that structured with a Three-tier Architecture, seamlessly integrated with a Microsoft SQL Server Database. It utilizes the capabilities of .NET Windows Form technology , written in C# programming language and follows the principles of Object-Oriented Programming (OOP).

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

## Admin access
The application includes an admin user with default credentials for testing purposes:
- **Username** : admin
- **Password** : admin

## Screenshots
Here are some screenshots from the application:

**login**

<img width="515" alt="login" src="https://github.com/ayaalshouha/DVLD-driving-and-vehicles-licenses-development/assets/129595827/05df2331-6a18-4639-8fde-e4a35ce28104">

**Invalid login** 

<img width="508" alt="invalidLogin" src="https://github.com/ayaalshouha/DVLD-driving-and-vehicles-licenses-development/assets/129595827/623af478-c592-4a2b-bf81-2c1dba9b3f48">

**Main Menu** 

<img width="948" alt="mainmenu" src="https://github.com/ayaalshouha/DVLD-driving-and-vehicles-licenses-development/assets/129595827/eaadd092-ce01-494a-9ea8-46e036afc3f5">

**Input Validation** 

<img width="680" alt="Input validation" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/12f8eaf0-8fab-4834-8ec9-fdd4ab0925d8">

**Filter Feature** 

<img width="667" alt="Filtering feature" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/b7e7fb93-c5ad-4176-83a6-edadf3703929">

**ContextMenuStrip Feature Customized for each DataGridView**

<img width="960" alt="ContextMenuStrip options" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/58d7c07d-552a-4662-ba5c-b017a8e88adf">

**Driver Licenses History** 

<img width="960" alt="Driver licenses history" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/d6ad5aaa-1d29-4cb0-a7c2-0db58e27c39f">

**Showing certain options in ContextMenuStrip_Opening for each application depends on its status** 

<img width="960" alt="Filtering" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/cbe375cb-353b-41cf-a26c-b388a068ef7d">

**Schedule Tests depends on previous tests result** 

<img width="960" alt="schedule tests" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/dc2d63bc-835b-44c9-97aa-40fed4a066fa">


**Adding Appointments and linked it to appointments database**

<img width="960" alt="Adding appointment" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/4e50df7c-8ade-4cf8-8147-cdc820944074">

**Appointments Options** 

<img width="960" alt="appointment options" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/4fbb6451-cc09-48d6-9087-7b804dc7eb8a">

**Taking Tests** 

<img width="960" alt="taking test" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/1230fafc-38cd-49e0-81cc-bc139975b279">

**Issue a license after passing all tests** 

<img width="960" alt="issue licenses" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/3aa9fc65-37c6-4056-91f6-0bb505e3a8e2">

**Final licenes Card** 

<img width="960" alt="licenes card" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/3dc21766-ad31-4d3f-bfaa-5046f86740c1">

**Current Account Setting** 

<img width="960" alt="currentAccountSettings" src="https://github.com/ayaalshouha/DVLD-driving-and-vehicles-licenses-development/assets/129595827/eae9d031-4f0b-4d14-82f6-abc7750c98dd">

**Updating Password** 

<img width="960" alt="change password" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/2303a040-21cb-44da-98cd-55d3b58318eb">

**Manage Drivers** 

<img width="960" alt="manage drivers" src="https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment/assets/129595827/4762af26-3a3f-47e0-9d7e-7f3166e7c712">

## Compilation 

1- **Clone The Repository** : 

   ```bash
git clone https://github.com/ayaalshouha/DVLD---Driving-Licenses-Managment.git
cd DVLD---Driving-Licenses-Managment
```

 2- **Compile The Code** : 
  - **For Visual Studio** :
     - Open the project in Visual Studio and compile using the IDE.

## Execution 

- **For Visual Studio**:
     - Run the compiled application from within the Visual Studio Community IDE.
  
 - **For Windows** :
```bash
   DVLD - Driving Licenses Managment.exe
```

## Contact
For inquiries or assistance, contact the project owner at **aya.alshouha11@gmail.com**.

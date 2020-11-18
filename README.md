# Seed code - Boilerplate for step-1 News App Assignment

## Assignment Step Description

As a first step in building our News application, we will create a monolithic application. 

A monolithic application is built as a single unit. Enterprise Applications are built in three parts: 

1. A database (consisting of many tables usually in a relational database management system)
2. A client-side user interface (consisting of HTML pages and/or JavaScript running in a browser)
3. A server-side application.

This server-side application will handle HTTP requests, execute some domain specific logic, retrieve and update data from the persistence storage, and populate the HTML views to be sent to the browser. 

### Problem Statement

In this case study: News App Step 1, we will develop a monolithic application which will get the title,content, date and image from the user using a form (Razor), persist the data in List and display all news sorted by date in tabular format.

**Note: For detailed clarity on the class files, kindly go thru the Project Structure**

### Expected solution

 >- A form containing input fields for Title, Content, Publishing Date, Image upload and a submit button.
 >- Partial view should be created to display News details in tabular format with the fields Image (thumbnail) ,Title and a button to delete. This partial view should be rendered as the part of landing page containing the form mentioned in previous point. 
 >- When the user clicks on the title of News, it should redirect to another view to display the complete details about the news.
 
### Steps to be followed

    Step 1: Clone the boilerplate in a specific folder in your local machine.
    Step 2: In News.cs file (which is considered as Model class), declare all the necessary properties for the model.
    Step 3: In NewsRepository.cs, create methods to add/retrieve/delete news from the List. 
    Step 4: Run the test cases for NewsRepository(NewsRepositoryTest.cs)
    Step 5: In NewsController.cs, get NewsRepository objects using dependency Injection.
    Step 6: Run the testcases for NewsController (NewsControllerTest.cs)
    Step 7: Design a form as per the requirements mentioned above.

### Project structure

The folders and files you see in this repositories, is how it is expected to be in projects, which are submitted for automated evaluation by Hobbes
```
📦News-Step-1
 ┣ 📂News-WebApp
 ┃ ┣ 📂Controllers
 ┃ ┃ ┗ 📜NewsController.cs //Class to define Action methods
 ┃ ┣ 📂Models
 ┃ ┃ ┗ 📜News.cs //Class to define News structure
 ┃ ┣ 📂Repository
 ┃ ┃ ┣ 📜INewsRepository.cs //Contract to define operations
 ┃ ┃ ┗ 📜NewsRepository.cs //Class to implement operations
 ┃ ┣ 📂Views //Folder containing all the views
 ┃ ┣ 📜Program.cs
 ┃ ┗ 📜Startup.cs //Define DI
 ┣ 📂test
 ┃ ┣ 📜NewsControllerIntegrationTest.cs //Integration testing
 ┃ ┣ 📜NewsControllerTest.cs //Unit Test for controller
 ┃ ┣ 📜NewsRepositoryTest.cs //Unit Test for respository
 ┃ ┣ 📜PriorityOrderer.cs //Don't change this class
 ┗ 📜News-Step-1.sln
 ```
"# NewsApp-Step1-Boilerplate" 

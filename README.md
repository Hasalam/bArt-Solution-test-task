# bArt-Solution-test-task
This is a test task for bArt solution

Whole project is stored on master branch

Project itself is simple CRUD app, developed using .Net 5, Entity Framework and Razor pages.
It stores info about employees of some companies. In particular, it stores their contact email and 
conflict with other members.

Employee cannot have more than one Incident, but can have many contacts.

# To run project on your computer:
1. Clone repo to your local machine using `git clone` command
2. In appsettings.json change connection string according to your database
3. In Package Manager Console type `add-migration migrationname` and than type `update-database`
4. Application should be set up and ready for work

When you first open site, you should register, by pushing button on layout.
After that you should be able to add/delete contact info and add/delete Incident info
!If you try to create Incident with username that isn't in database, you will receive 404 error

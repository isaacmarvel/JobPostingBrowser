# JobPostingBrowser

## Dependencies

- Quasar; can be installed with: `npm i -g @quasar/cli`

## Running
You will need a 3rd party API key for the Reed job postings that I'm pulling. This will need to be added in a launchSettings.Jjson file as an environmentVariable (under "profiles"), in a Properties folder in JobPostingBrowser.Api. Code Louisville mentors--I will include my launchSettings file in a google drive in my project submission, so you can copy that into your own. 


For the api:
Run JobPostingBrowser.Api in Visual studio or with "dotnet run" in the command line.
Run migrations via Entity Framework

For the web app:
In a separate command line window, navigate to JobPostingBrowser.App and run "npm install", thenstart the app with "quasar dev".

## Overview
This project allows users to view and save job postings via a Vue web app. Job postings come from the Reed job api, and I'm using ASP.NET on the backend to communicate with Reed and my frontend. Postings are saved to a SQLite database via EF. Unfortunately Reed's job are European, but it works well enough as a proof of concept.

Code Louisville features used: 1. "Make your application an API", 2. "Make your application a CRUD API", and 3. "Make your application asynchronous." All three of these are fulfilled on the backend, which features an ASP.NET api that allows you to perform CRUD operations on job data coming from my front end (actually you can only create, read, and delete, since I don't see a need to update them, but close enough). 

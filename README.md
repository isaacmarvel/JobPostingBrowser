# JobPostingBrowser

## Dependencies

- Quasar; can be installed with: `npm i -g @quasar/cli`

## Running

You will need an API key for the Reed job postings that I'm pulling. This will need to be added in a launchSettings.Json file as an environmentVariable (under "profiles"), in a Properties folder in JobPostingBrowser.Api.

For the api:
Run JobPostingBrowser.Api in Visual studio or with "dotnet run" in the command line.
Run migrations via Entity Framework

For the web app:
In a separate command line window, navigate to JobPostingBrowser.App and run "npm install", then start the app with "quasar dev".

## Overview

This project allows users to view and save job postings via a Vue web app. Job postings come from the Reed job api, and I'm using ASP.NET on the backend to communicate with Reed and my frontend. Postings are saved to a SQLite database via EF. Unfortunately Reed's job are European, but it works well enough as a proof of concept.

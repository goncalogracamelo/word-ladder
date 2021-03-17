# WordLadder Algorithm Implementation

## Approach Strategy

Creating some initial abstractions and concepts around the problem. 
Word, Dictionary and WordPath were the first ones to implement and validated by using UnitTests. These helped me to create a sense of the domain.
The the first strategy implemented was Breadth First - complete and optimizes for the shortest solution.

## Global Solution Architecture

Dotnet Core (3.1) console Application, imlpemented using the Dotnet core Host process to use: Dependency Injection, Logging configuration and abstractions and configuration file.

Complete solution is based in an onion architecture (simplified clean architecture). Projects:
- WordLadder.Main: ConsoleApplication with the application start point. Contains all the startup configurations and validations like Logging, Dependency injection and configurations. Will run the Main service in the Dotnet core host process created. Depends on all projects.
- WordLadder.Application: Application Services (Core). Contains Services and Doamin classes. Do not dependend on any other project. 
-- Inversion of Control is used for any external dependency.
-- Strategy pattern to impement multiple search implementations.
- WordLadder.Infrastructure: Outer most classes. Will contain all the concrete implementaions for all infrastruture like I/O, Apis, Database. Thy must implement the interface defined in the Application project.
Will only depend on the WordLadder.Application project.
WordLadderUnitTests

## External Libraries

- I/O File Operations: https://www.filehelpers.net/ - 
- Logging: Serilog - Log.File.Sink
- Unit tests: Xunit and Mock

## Solution Main Points

The domain concepts:
- Word
- WordPath: A list of Words
- SolutionNode: A WordPath and the Node Word and a method to generate all the next words
- WordDictionary

The Service implements a simple Breadth first strategy.

## Algorithm Improvements

- Add an Heuristic to improve the next node decision
- Try a bi-deraction search

## Performance Improvements

- Dictionary implementation 
Improve the search for the the word options. Create an organization of word buckets for all words that are different by one character.
https://bradfieldcs.com/algos/graphs/word-ladder/9

- Implement Async Logic
- Add more validations to the program input parameters (evaluate using FluentValition package for example)
- Add more execution metrics that will collect more information from the running application

## Run the Programhnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnhnh

WordLadder.Console.exe <start-word> <end-word> <dictionary-full-path> <output-file-full-path>

Example:
WordLadder.Console.exe "hide" "sort" "C:\temp\WordLadder\words-english.txt" "C:\temp\WordLadder\ouput.txt"


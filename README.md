# _Hair Salon_

#### _This application will allow the user(Owner of salon) to create a list of Stylists and a see who their clients are. 7/15/16_

#### By _**James R. Howard**_

## Description

_This application will allow the user to create a list of stylists stored in a database and their respective clients. Clients can have only one stylist._

## Setup Requirements

* _Internet_
* _Clone project from GitHub_
* _Windows OS (or bootcamp with Windows OS_
* _Windows Powershell_
* _Mono_
* _Microsoft SQL management studio_

## Installation Requirements
* _Once you have all the Setup Requirements, use the Windows Powershell to > git clone._
* _Then navigate to the project folder and run the command >dnu Restore._
* _Then run > sqlcmd -S '(localdb)\mssqllocaldb'_
* _Then run > CREATE DATABASE hair_salon;_
* _Then run > GO_
* _Then run > USE hair_salon_
* _Then run > GO_
* _Then run > CREATE TABLE clients (id INT IDENTITY(1,1), client VARCHAR(255));_
* _Then run > CREATE TABLE stylists (id INT IDENTITY(1,1), stylist VARCHAR(255), client_id INT);_
* _After that run the command >dnx kestrel_
* _Open up a web browser(Project was built and tested on Google Chrome) and go to http:localhost:5004._

## Known Bugs

_Issues with HomeModule Dictionary running error('System.Collections.Generic.KeyValuePair' does not contain a definition for 'GetId'). unable to fix problem and didnt get arround to implementing more views and CRUD via HomeModule.(will attempt to fix at home in another branch but not merger it)_

## Support and contact details

_Feel free to contact me at jrh682@gmail.com_

## Technologies Used

_HTML, atom, Windows Powershell, Mono, Nancy version: "1.3.0", xUnit version: "2.1.0", RazorViewEngine version: "1.3.0", Microsoft SQL management studio_

### License

*The MIT License (MIT)
Copyright (c) 2016, James R. Howard

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.*

Copyright (c) 2016 **_{James R. Howard, student at EPICODUS}_**

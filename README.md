FuelSDK-CSharp
============

Salesforce Marketing Cloud Fuel SDK for C#

Master | Development | NuGet
---|---|---
[![Build Status](https://travis-ci.org/pepperpark/FuelSDK-CSharp.svg?branch=master)](https://travis-ci.org/pepperpark/FuelSDK-CSharp) [![Coverage Status](https://coveralls.io/repos/github/pepperpark/FuelSDK-CSharp/badge.svg?branch=master)](https://coveralls.io/github/pepperpark/FuelSDK-CSharp?branch=master)|[![Build Status](https://travis-ci.org/pepperpark/FuelSDK-CSharp.svg?branch=development)](https://travis-ci.org/pepperpark/FuelSDK-CSharp)  [![Coverage Status](https://coveralls.io/repos/github/pepperpark/FuelSDK-CSharp/badge.svg?branch=development)](https://coveralls.io/github/pepperpark/FuelSDK-CSharp?branch=development)|[![NuGet](https://img.shields.io/nuget/dt/FuelSDK-netstandard.svg)](https://www.nuget.org/packages/FuelSDK-netstandard/0.0.1-alpha)

## New Features in Version 1.0.0 ##
* **code refactor :** code refactored to individual class files. Classes starting with “ET_” are deprecated now and all SDK API objects start with “ET”. 

Project tree structure 
- FuelSDK-CSharp : SDK Project 
- FuelSDK.Test   : NUnit test project
- objsamples     : Sample/Example project
- docs           : SDK API HTML documentation 

* **NUnit test case :** Nunit test case project added. This covers basic happy path testing. All the test cases use “ET” classes. For samples that uses “ET_” classes, please see “objsamples” project. Advanced and more comprehensive test cases will be added in future releases.

* **API docs :** added API documentation using doxygen documentation framework. (under docs/ directory)

* **JWT :** JWT.cs is removed from the project and added as dependency.

## Documentation ##
[Salesforce Marketing Cloud API Document](http://salesforce-marketingcloud.github.io/FuelSDK-CSharp).

## Requirements ##
- .NET Studio 2013 or higher (WCF)
- .NET Framework 4 

Dependencies:
JWT v3.0.0
Newtonsoft.Json v10.0.3

## Installation ##

Add Salesforce Marketing Cloud Fuel SDK nuget package using the following command in the package manager console:

<pre> Install-Package SFMC.FuelSDK </pre>
All necessary settings are in App.config.transform file.

## Getting Started ##
The FuelSDK-CSharp solution file includes two projects. One for the actual SDK and one for a web based testing app as an example of how to use the SDK dll and other dependent files.

Rename the  FuelSDK_config.xml.template file in the objsamples project to FuelSDK_config.xml, then edit so you can input the ClientID and Client Secret values provided when you registered your application. If you are building a HubExchange application for the Interactive Marketing Hub then, you must also provide the Application Signature (appsignature). Only change the value for the defaultwsdl configuration item if instructed by Salesforce Marketing Cloud.

If you have not registered your application or you need to lookup your Application Key or Application Signature values, please go to App Center at [Salesforce Marketing Cloud's Developer Community]( https://appcenter-auth.s1.marketingcloudapps.com).

## Example Request ##
All Salesforce Marketing Cloud services exposed through the Fuel SDK begin with be prefixed with "ET". Start by working with the ETList object:

Add a using statement to reference the FuelSDK's functionality:
<pre>

>using FuelSDK;

Next, create an instance of the ETClient class:

>ETClient myclient = new ETClient();            

Create an instance of the Salesforce Marketing Cloud we want to work with:

>ETList list = new ETList();

Associate the ETClient to the object using the client property:

>list.authStub = myclient;

Utilize one of the ETList methods:

>GetReturn getFR = list.Get();


Print out the results for viewing


>Console.WriteLine("Get Status: " + getFR.Status.ToString());
>
>Console.WriteLine("Message: " + getFR.Message.ToString());
>
>Console.WriteLine("Code: " + getFR.Code.ToString());
>
>Console.WriteLine("Results Length: " + getFR.Results.Length);

>foreach (ETList ResultList in getFR.Results) <br />
>{<br/>
>&nbsp;&nbsp;&nbsp;Console.WriteLine("--ID: " + ResultList.ID + ", Name: " + ResultList.ListName + ", Description: " + ResultList.Description);
><br/>
>}
</pre>



## ETClient Class ##
The ETClient class takes care of many of the required steps when accessing Salesforce Marketing Cloud's API, including retrieving appropriate access tokens, handling token state for managing refresh, and determining the appropriate endpoints for API requests. In order to leverage the advantages this class provides, use a single instance of this class for an entire session. Do not instantiate a new ETClient object for each request made.

The ETClient class takes 1 parameter which is a NameValueCollection that can be used for passing authentication information for use with SSO with a JWT or for passing ClientID/ClientSecret if you would prefer to not use the config file option. 

Example passing JWT: 
> NameValueCollection parameters = new NameValueCollection();<br>
parameters.Add("clientId", "<your client id>");<br>
parameters.Add("clientSecret", "<your client secret>");<br>
parameters.Add("jwt", "JWT Value Goes Here");<br>
parameters.Add("appSignature", "j8hj87jhf54gfk54d2lijs");<br>
ETClient myclient = new ETClient(parameters);<br>

Example passing ClientID/ClientSecret only: 
> NameValueCollection parameters = new NameValueCollection();<br>
parameters.Add("clientId", "<your client id>");<br>
parameters.Add("clientSecret", "<your client secret>");<br>
ETClient myclient = new ETClient(parameters);<br>

Example passing flag for sandbox environment with ClientID/ClientSecret: 
> NameValueCollection parameters = new NameValueCollection();<br>
parameters.Add("clientId", "<your client id>");<br>
parameters.Add("clientSecret", "<your client secret>");<br>
parameters.Add("sandbox", "true");<br>
ETClient myclient = new ETClient(parameters);<br>

## Responses ##
All methods on Fuel SDK objects return an object that follows the same structure, regardless of the type of call. This object contains a common set of properties used to display details about the request.

- Status: Boolean value that indicates if the call was successful
- Code: HTTP Error Code 
- Message: Text values containing more details in the event of an error
- Results: Typed collection containing the results of the call.

Get Methods also return an addition value to indicate if more information is available (that information can be retrieved using the GetMoreResults method):

- MoreResults: Boolean value that indicates on Get requests if more data is available.


## Samples ##
The objsamples project (included in solution) contains sample calls for all the available functionality.

## Copyright and license ##
Copyright (c) 2017 Salesforce Marketing Cloud

Licensed under the MIT License (the "License"); you may not use this work except in compliance with the License. You may obtain a copy of the License in the COPYING file.

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.

# ITSM Process & Operations - Technology - Coding Exercise

* This is the GitHub URL: https://github.com/yaplex/address-book


## Some highlights: 
Based on the requirements and provided template the app looks like SPA, so I **used Angular instead of jQuery**, I feel like that is a better alternative.
The app is ready to run on local, but you may need a `node.js` to execute. 
To run on local you need to run client and server-side.
To run client-side switch to \address-book\ITSMCodingTest\angular-client and run 
`
npm install
npm run watch
`

* The backend (API and Entity framework) you can run from the Visual Studio as usual. 
* I extracted all HTML from Index.html into Angular and inside Index.cshtml I have only `<app-root></app-root>`
* I used Web.API (see API folder) where I used CQRS with `MediatR`. I also add `Autofac` for Dependency injection and `AutoMapper`
* All long-running operations like save/delete/update have a **1-second delay** on the server to display the loading overlay.

Countries provider API calling 3rd party service, **caching** the response for 1 hour. In case when 3rd party service is down, I have a list of default countries as a **fallback**.

### You can click on the address and will be navigated to Google Maps.

Below are just a couple of screenshots in case live app is down.

![2](https://user-images.githubusercontent.com/1596776/172030455-a5a3518e-1107-4b98-b906-b6be3e359e89.png)
![1](https://user-images.githubusercontent.com/1596776/172030456-e27025d7-1562-4f90-b4ab-c17991237343.png)
![3](https://user-images.githubusercontent.com/1596776/172030457-5d9790a5-b0d5-4259-b8f4-f1512936a614.png)
![4](https://user-images.githubusercontent.com/1596776/172030759-ca0e3378-1955-4586-a522-ddb38512f8f2.png)



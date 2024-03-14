# Sopost

Sopost is a role management tool, implementing the basic crud operations such as signup, login, reset , update password and much more.

## Installation
Clone the [Sopost Repository](https://github.com/uday-biswas/sopost) from [GitHub](http://www.github.com) so that you have the project locally.
```sh
git clone https://github.com/uday-biswas/sopost.git
```

### Required software for development

- [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [ASP.Net 6.0 command-line interface (CLI)](https://dotnet.microsoft.com/en-us/download) (Required)
- [Visual Studio Code](https://code.visualstudio.com/download) or other editor
- [Postman](https://www.postman.com/downloads/) for testing API calls

### Installing Angular package dependencies

After you have cloned the Analysim repository on your local machine,
use the terminal to navigate to the
`Sopost/ClientApp` folder and run the following
command.

```sh
npm install
```

### Connecting to databases and other services

Sopost requires sql server database. In addition, an gmail account is needed for the email functionality. All of these services are accessed via authentication information stored in the `appsettings.json` and `appsettings.Development.json` files under the `Sopost/Api` folder. The structure of the files are as follows:  

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;Persist Security Info=False;User ID=YOUR_USERNAME;Password=XXX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;",
  },
  "JWT": {
    "Key": "G6ZjGyuKnKabrdrPf27oj7RQHWl2kxl6",
    "ExpiresInMinutes": 30,
    "RefreshTokenExpiresInDays": 1,
    "Issuer": "https://localhost:4200",
    "ClientUrl": "https://localhost:4200"
  },
  "Email": {
    "Server": "smtp.gmail.com",
    "Port": 587,
    "SenderName": "no-reply-Sopost",
      "SenderEmail": "YOUR_EMAIL_ADDRESS",
    "Username": "YOUR_EMAIL_ADDRESS",
    "Password": "YOUR_PASSWORD",
    "ConfirmEmailPath": "account/confirm-email",
    "ResetPasswordPath": "account/reset-password"
  },
  "Facebook": {
    "AppId": "YOUR_APPID",
    "AppSecret": "YOUR_APP_SECRET"
  },
  "Google": {
    "ClientId": "YOUR_GOOGLE_CLIENT"
  }
}

```

### Running the project

**Step 1:**

In **Visual Studio Code** (or other editor), open up the Sopost
project folder.  Using a terminal, navigate to
`ClientApp` and run the following command (also works
from Command Line):

```
ng serve -o
```

**Step 2:**

Next, in **Visual Studio**, open up the `Sopost.sln` file.  Click on
the run to start the project.  Once you have completed both steps,
your project should be up and running! 

Alternatively, without Visual Studio, you use .Net CLI from command
line by first navigating into the `Api` folder:

```sh
dotnet run
```

### Thank you !!!
**Please star the repo , if you like it**

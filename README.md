
# BackEnd
Backend of GarageMeet Repository

## Getting Started

### Checkout the API

You can interface with the GarageMeet API at [GarageMeetAPI](https://garagemeet.azurewebsites.net/).

Checkout an an example endpoint for retrieving a [user's comments](https://garagemeet.azurewebsites.net/Comment/GetComment/1) by their user id.

### Contribute to the project

#### Windows/Linux/MacOS

- Set up [Git](https://docs.github.com/en/get-started/quickstart/set-up-git)
- Clone this repository to your machine with `git clone https://github.com/Revature-GarageMeet/BackEnd.git`
- install [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download)
- To launch the web API locally, go to your repository directory and `cd WebAPI` and `dotnet run --configuration Debug`
- If you have made changes that you would like to add to the project then fork this repository to yor GitHub account, `git add <file>` your changes, `git commit -m <commit message>` to commit your changes, push your commit with `git push`, and [create a pull request](https://github.com/marketplace/actions/create-pull-request#:~:text=Action%20inputs%20%20%20%20Name%20%20,%5Bcreate-pull-request%5D%20automated%20change%20%2016%20more%20rows%20) on this GitHub repository.

HI ITS LEO IMPORTANT, I PUSHED THE APPSETTINGS ON ACCIDENT SO ALL OF YOU GUYS HAVE IT AND IT SHOULDNT BE PUSHED PLEASE LOOK AT THIS AND REMEMBER TO FIX IT

also delete ^ when you do  ~leo

reminding myself for later
cd /WebAPI
git rm -r --cached appsettings.json
git rm -r --cached appsettings.Development.json
git commit -m "Removed appsettings to hide our super secret password to db"
git push origin Leo

This is here to test continuous deployment on a merged pull request

## Getting Started

### Checkout the API

You can interface with the GarageMeet API at [GarageMeetAPI](https://garagemeet.azurewebsites.net/).

Checkout an an example endpoint for retrieving a [user's comments](https://garagemeet.azurewebsites.net/Comment/GetComment/1) by their user id.

### Serve API locally and Contribute to the project

#### Windows/Linux/MacOS

- Set up [Git](https://docs.github.com/en/get-started/quickstart/set-up-git)
- Fork this repository to your GitHub account and then clone the repository to your local machine with `git clone <url-to-your-forked-repo>`
- install [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download)
- To launch the web API locally, go to your repository directory and `cd WebAPI` and `dotnet run --configuration Debug`
- If you have made changes that you would like to add to the project then fork this repository to yor GitHub account, `git add <file>` your changes, `git commit -m <commit message>` to commit your changes, push your commit with `git push`, and [create a pull request](https://github.com/marketplace/actions/create-pull-request#:~:text=Action%20inputs%20%20%20%20Name%20%20,%5Bcreate-pull-request%5D%20automated%20change%20%2016%20more%20rows%20) on this GitHub repository.

### Setup CI/CD

#### CD
Docker containerization and continuous deployment can be set up following [docker-cd.yml](https://github.com/Revature-GarageMeet/BackEnd/blob/main/.github/workflows/docker-cd.yml).

#### CI
Continuous testing can be setup by following [ci.yml](https://github.com/Revature-GarageMeet/BackEnd/blob/main/.github/workflows/ci.yml).


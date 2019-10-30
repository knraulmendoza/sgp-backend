node {

  stage('Checkout') {
    git url: 'https://github.com/menkemon/sgp-backend.git',branch: 'master'
  }
   stage('Restore Nuget') {
    bat 'dotnet restore webapi/webapi.sln'
  }
  
  stage('Clean') {
    bat 'dotnet clean webapi/webapi.sln'
  }
  
  stage('Build') {
    bat 'dotnet build webapi/webapi.sln'
  }


  stage('Publish') {
    bat 'dotnet publish webapi/webapi.sln -o C:/ws/'
  }
  
}

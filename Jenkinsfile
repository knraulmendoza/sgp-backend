node {

  stage('Checkout') {
    git url: 'https://github.com/menkemon/sgp-backend.git',branch: 'master'
  }
  //SignusFinanciero.sln
  stage ('Restore Nuget') {
      bat "dotnet restore -s https://github.com/menkemon/sgp-backend/tree/master/Dominio -s https://github.com/menkemon/sgp-backend/tree/master/Infraestructura -s https://github.com/menkemon/sgp-backend/tree/master/WebApi"
  }
  
  stage('Clean') {
    bat 'dotnet clean'
  }
  
  stage('Build') {
    bat 'dotnet build'
  }


  stage('Publish') {
    bat 'dotnet publish'
  }
  
}

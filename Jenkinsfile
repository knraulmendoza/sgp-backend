node {

  stage('Checkout') {
    git url: https://github.com/menkemon/sgp-frontent.git,branch: 'master'
  }
  //SignusFinanciero.sln
  stage ('Restore Nuget') {
    bat "dotnet restore"
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
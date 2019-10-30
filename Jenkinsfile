node {

  stage('Checkout') {
    git url: 'https://github.com/menkemon/sgp-backend.git',branch: 'master'
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

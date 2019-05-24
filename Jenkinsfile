pipeline {
    agent {
        docker { image 'node:7-alpine' }
    }
    stages {
        stage('TestTao') {
            steps {
                bat 'node --version'
            }
        }
    }
}
pipeline {
    agent {
        docker { image 'node:7-alpine' }
    }
    stages {
        stage('TestTao') {
            steps {
                sh 'node --version'
            }
        }
    }
}
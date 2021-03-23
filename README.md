# [Financial Peace Web](https://github.com/KrylixZA/FinancialPeace-Web)  [![CI](https://github.com/KrylixZA/FinancialPeace-Web/actions/workflows/ci.yml/badge.svg)](https://github.com/KrylixZA/FinancialPeace-Web/actions/workflows/ci.yml)
A Blazor Web Assembly application to serve as a user interface for the Financial Peace application in conjunction with the the [FinancialPeace-Database](https://github.com/KrylixZA/FinancialPeace-Database) and [FinancialPeace-Web-Api](https://github.com/KrylixZA/FinancialPeace-Web-Api) to solve your financial concerns.

# Docker
This application is also built into a [Docker image](Dockerfile) and hosted on [Docker Hub](https://hub.docker.com/repository/docker/krylixza/financialpeace-web).

## Running the application
In the repository is a [docker-compose.yml](docker-compose.yml) file. Use this file to launch the Web interface, Web API and the database. To do this, simply clone the repository, open your CLI and run:

    docker-compose up

## ARM support
If you have a device running on an ARM processor, there is both an ARM Docker image and a `docker-compose.arm.yml` to launch the API in an ARM Docker container. To do this, run the following command:

    docker-compose -f "docker-compose.arm.yml" up

# Contribute
To contribute to this project, please following the [contributing guide](CONTRIBUTING.md).

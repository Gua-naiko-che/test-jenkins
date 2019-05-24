FROM microsoft/dotnet:2.2-sdk AS build

# Install required packages
RUN apt-get update && apt-get install -y \
    curl \
    wget \
    dos2unix \
    unzip \
    --no-install-recommends

# Install Chrome (for versions of chrome, look at https://www.ubuntuupdates.org/pm/google-chrome-stable)
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list' \
    && apt-get update \
    && apt-get install -y google-chrome-stable --no-install-recommends \ 
    && rm -rf /var/lib/apt/lists/* \
    && rm -rf /src/*.deb

# Install Selenium Chrome driver. Version xml list here: https://chromedriver.storage.googleapis.com
# There should be a certain match between your chrome and chromedriver version. In general chromedriver version > chrome version. See compatilbities here: https://sites.google.com/a/chromium.org/chromedriver/downloads
# Can specify versions by CHROME_DRIVER_VERSION. Latest released version will be used by default
WORKDIR /src
ARG CHROME_DRIVER_VERSION="latest"
RUN CD_VERSION=$(if [ ${CHROME_DRIVER_VERSION:-latest} = "latest" ]; then echo $(wget -qO- https://chromedriver.storage.googleapis.com/LATEST_RELEASE); else echo $CHROME_DRIVER_VERSION; fi) \
    && echo "Using chromedriver version: "$CD_VERSION \
    && rm -f chromedriver_linux64.zip \
    && curl https://chromedriver.storage.googleapis.com/$CD_VERSION/chromedriver_linux64.zip -o chromedriver_linux64.zip \
    && mkdir -p bin/Debug/netcoreapp2.2/ \
    && unzip chromedriver_linux64.zip -d bin/Debug/netcoreapp2.2/ \
    && chmod +x bin/Debug/netcoreapp2.2/chromedriver

COPY . .
ENTRYPOINT ["dotnet", "test"]
param webAppName string
param location string
param planId string

resource webApp 'Microsoft.Web/sites@2021-01-01' = {
  name: webAppName
  location: location
  properties: {
    serverFarmId: planId
  }
}
